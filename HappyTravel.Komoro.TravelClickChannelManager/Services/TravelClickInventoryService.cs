using HappyTravel.Komoro.Common.Infrastructure;
using HappyTravel.Komoro.Common.Services.Availabilities;
using HappyTravel.Komoro.TravelClickChannelManager.Infrastructure.Extensions;
using HappyTravel.Komoro.TravelClickChannelManager.Models;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Response;
using HappyTravel.KomoroContracts.Availabilities;

namespace HappyTravel.Komoro.TravelClickChannelManager.Services;

public class TravelClickInventoryService : ITravelClickInventoryService
{
    public TravelClickInventoryService(IDateTimeOffsetProvider dateTimeOffsetProvider, IInventoryService inventoryService)
    {
        _dateTimeOffsetProvider = dateTimeOffsetProvider;
        _inventoryService = inventoryService;
    }


    public async Task<OtaHotelInvCountRS> Get(OtaHotelInvCountRQ otaHotelInvCountRQ, CancellationToken cancellationToken)
    {
        var request = otaHotelInvCountRQ.HotelInvCountRequests.Single();
        var hotelCode = request.HotelRef.HotelCode;

        Success? success = null;
        List<Warning>? warnings = null;
        List<Error>? errors = null;
        Models.Availabilities.Inventories inventories = new();

        var inventoryRequest = new InventoryRequest
        {
            SupplierCode = Constants.TravelClickCode,
            PropertyCode = hotelCode,
            StartDate = DateOnly.FromDateTime(request.DateRange.Start),
            EndDate = DateOnly.FromDateTime(request.DateRange.End),
            RoomTypeCodes = request.RoomTypeCandidates.Select(rpc => rpc.RoomTypeCode).ToList()
        };

        var (inventory, errorDetails) = await _inventoryService.Get(inventoryRequest);

        if (errorDetails.Any())
        {
            errors = errorDetails.Select(ed => ed.ToError())
                .ToList();
        }
        else
        {
            success = new();
            var inventoryList = inventory.InventoryDetails.Select(id => id.ToInventory())
                .ToList();

            inventories = new Models.Availabilities.Inventories
            {
                HotelCode = hotelCode,
                InventoryList = inventoryList
            };
        }

        return new OtaHotelInvCountRS
        {
            Version = otaHotelInvCountRQ.Version,
            TimeStamp = _dateTimeOffsetProvider.UtcNow(),
            EchoToken = otaHotelInvCountRQ.EchoToken,
            Success = success,
            Errors = errors,
            Warnings = warnings,
            Inventories = inventories
        };
    }


    public async Task<OtaHotelInvCountNotifRS> Update(OtaHotelInvCountNotifRQ otaHotelInvCountNotifRQ, CancellationToken cancellationToken)
    {
        var hotelCode = otaHotelInvCountNotifRQ.Inventories.HotelCode ?? string.Empty;

        Success? success = null;
        List<Warning>? warnings = null;
        List<Error>? errors = null;

        var inventory = new Inventory
        {
            SupplierCode = Constants.TravelClickCode,
            PropertyCode = hotelCode,
            InventoryDetails = otaHotelInvCountNotifRQ.Inventories.InventoryList.Select(i => i.ToInventoryDetails()).ToList()
        };

        var errorDetails = await _inventoryService.Update(inventory);
        if (errorDetails.Any())
        {
            errors = errorDetails.Select(ed => ed.ToError())
                .ToList();
        }
        else
        {
            success = new();
        }

        return new OtaHotelInvCountNotifRS
        {
            Version = otaHotelInvCountNotifRQ.Version,
            TimeStamp = _dateTimeOffsetProvider.UtcNow(),
            EchoToken = otaHotelInvCountNotifRQ.EchoToken,
            Success = success,
            Errors = errors,
            Warnings = warnings
        };
    }


    private readonly IDateTimeOffsetProvider _dateTimeOffsetProvider;
    private readonly IInventoryService _inventoryService;
}

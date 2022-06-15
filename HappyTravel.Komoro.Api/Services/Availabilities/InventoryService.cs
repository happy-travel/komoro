using HappyTravel.Komoro.Api.Infrastructure.ModelExtensions.Availabilities;
using HappyTravel.Komoro.Api.Services.Statics;
using HappyTravel.Komoro.Common.Infrastructure;
using HappyTravel.Komoro.Common.Services.Availabilities;
using HappyTravel.Komoro.Common.Services.Statics;
using HappyTravel.Komoro.Data;
using HappyTravel.KomoroContracts;
using HappyTravel.KomoroContracts.Availabilities;
using Microsoft.EntityFrameworkCore;
using DataModels = HappyTravel.Komoro.Data.Models.Availabilities;

namespace HappyTravel.Komoro.Api.Services.Availabilities;

public class InventoryService : IInventoryService
{
    public InventoryService(KomoroContext komoroContext, IDateTimeOffsetProvider dateTimeOffsetProvider, IPropertyService propertyService, 
        IRoomTypeService roomTypeService, IRatePlanService ratePlanService)
    {
        _komoroContext = komoroContext;
        _dateTimeOffsetProvider = dateTimeOffsetProvider;
        _propertyService = propertyService;
        _roomTypeService = roomTypeService;
        _ratePlanService = ratePlanService;
    }


    public async Task<(Inventory, List<ErrorDetails>)> Get(InventoryRequest request)
    {
        if (!await _propertyService.IsExist(request.SupplierCode, request.PropertyCode))
            return (new(), new List<ErrorDetails>
                { new ErrorDetails { ErrorCode = KomoroContracts.Enums.ErrorCodes.InvalidProperty, EntityCode = request.PropertyCode } });

        var errorDetailsList = new List<ErrorDetails>();
        foreach (var roomTypeCode in request.RoomTypeCodes)
        {
            if (!await _roomTypeService.IsExist(roomTypeCode))
                errorDetailsList.Add(new ErrorDetails { ErrorCode = KomoroContracts.Enums.ErrorCodes.InvalidRoomType, EntityCode = roomTypeCode });
        }
        if (errorDetailsList.Count > 0)
            return (new(), errorDetailsList);

        var inventoryDetails = await _komoroContext.Inventories
            .Include(i => i.Property)
            .Include(i => i.RoomType)
            .Where(i => i.Property.SupplierCode == request.SupplierCode
                && i.Property.Code == request.PropertyCode
                && request.RoomTypeCodes.Contains(i.RoomType.Code)
                && ((i.StartDate <= request.StartDate && i.EndDate >= request.EndDate)
                    || (i.StartDate >= request.StartDate && i.EndDate <= request.EndDate)
                    || (i.StartDate >= request.StartDate && i.StartDate <= request.EndDate)
                    || (i.EndDate >= request.StartDate && i.EndDate <= request.EndDate)))
            .Select(i => i.ToApiInventoryDetails())
            .ToListAsync();

        var inventory = new Inventory
        {
            SupplierCode = request.SupplierCode,
            PropertyCode = request.PropertyCode,
            InventoryDetails = inventoryDetails
        };

        return (inventory, errorDetailsList);
    }


    public async Task<List<ErrorDetails>> Update(Inventory inventory)
    {
        var supplierCode = inventory.SupplierCode;
        var propertyCode = inventory.PropertyCode;
        if (!await _propertyService.IsExist(supplierCode, propertyCode))
            return (new List<ErrorDetails>
                { new ErrorDetails { ErrorCode = KomoroContracts.Enums.ErrorCodes.InvalidProperty, EntityCode = propertyCode } });

        var errorDetailsList = new List<ErrorDetails>();
        foreach (var inventoryDetails in inventory.InventoryDetails)
        {
            if (!await _roomTypeService.IsExist(inventoryDetails.RoomTypeCode))
                errorDetailsList.Add(new ErrorDetails { ErrorCode = KomoroContracts.Enums.ErrorCodes.InvalidRoomType, EntityCode = inventoryDetails.RoomTypeCode });

            if (!_ratePlanService.IsExist(inventoryDetails.RatePlanCode))
                errorDetailsList.Add(new ErrorDetails { ErrorCode = KomoroContracts.Enums.ErrorCodes.InvalidRatePlan, EntityCode = inventoryDetails.RatePlanCode });
        }
        if (errorDetailsList.Count > 0)
            return (errorDetailsList);

        foreach (var inventoryDetails in inventory.InventoryDetails)
        {
            var existingInventory = await _komoroContext.Inventories
                .Include(ar => ar.Property)
                .Include(ar => ar.RoomType)
                .SingleOrDefaultAsync(ar => ar.Property.SupplierCode == supplierCode
                    && ar.Property.Code == propertyCode
                    && ar.RatePlanCode == inventoryDetails.RatePlanCode
                    && ar.RoomType.Code == inventoryDetails.RoomTypeCode
                    && ar.StartDate == inventoryDetails.StartDate
                    && ar.EndDate == inventoryDetails.EndDate);
            var utcNow = _dateTimeOffsetProvider.UtcNow();

            if (existingInventory is null)
            {
                var propertyId = await _propertyService.GetId(supplierCode, propertyCode);
                var roomTypeId = await _roomTypeService.GetId(inventoryDetails.RoomTypeCode);
                var newInventory = new DataModels.Inventory
                {
                    StartDate = inventoryDetails.StartDate,
                    EndDate = inventoryDetails.EndDate,
                    PropertyId = propertyId,
                    RoomTypeId = roomTypeId,
                    RatePlanCode = inventoryDetails.RatePlanCode,
                    NumberOfAvailableRooms = inventoryDetails.NumberOfAvailableRooms,
                    NumberOfBookedRooms = inventoryDetails.NumberOfBookedRooms,
                    Created = utcNow,
                    Modified = utcNow
                };
                _komoroContext.Inventories.Add(newInventory);
            }
            else
            {
                existingInventory.NumberOfAvailableRooms = inventoryDetails.NumberOfAvailableRooms;
                existingInventory.NumberOfBookedRooms = inventoryDetails.NumberOfBookedRooms;
                existingInventory.Modified = utcNow;
                _komoroContext.Inventories.Update(existingInventory);
            }
            await _komoroContext.SaveChangesAsync();
        }

        return errorDetailsList;
    }


    private readonly KomoroContext _komoroContext;
    private readonly IDateTimeOffsetProvider _dateTimeOffsetProvider;
    private readonly IPropertyService _propertyService;
    private readonly IRoomTypeService _roomTypeService;
    private readonly IRatePlanService _ratePlanService;
}

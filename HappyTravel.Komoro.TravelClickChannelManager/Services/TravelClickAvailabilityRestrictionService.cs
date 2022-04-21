using HappyTravel.Komoro.Common.Infrastructure;
using HappyTravel.Komoro.Common.Services.Availabilities;
using HappyTravel.Komoro.Common.Services.Statics;
using HappyTravel.Komoro.TravelClickChannelManager.Infrastructure;
using HappyTravel.Komoro.TravelClickChannelManager.Infrastructure.Extensions;
using HappyTravel.Komoro.TravelClickChannelManager.Models;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Response;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Enums;
using HappyTravel.KomoroContracts.Availabilities;

namespace HappyTravel.Komoro.TravelClickChannelManager.Services;

public class TravelClickAvailabilityRestrictionService : ITravelClickAvailabilityRestrictionService
{
    public TravelClickAvailabilityRestrictionService(IDateTimeOffsetProvider dateTimeOffsetProvider, IPropertyService propertyService, IAvailabilityRestrictionService availabilityRestrictionService)
    {
        _dateTimeOffsetProvider = dateTimeOffsetProvider;
        _propertyService = propertyService;
        _availabilityRestrictionService = availabilityRestrictionService;
    }


    public async Task<OtaHotelAvailGetRS> Get(OtaHotelAvailGetRQ otaHotelAvailGetRQ, CancellationToken cancellationToken)
    {
        var request = otaHotelAvailGetRQ.HotelAvailRequests.First();
        var hotelCode = request.HotelRef.HotelCode;

        Success? success = null;
        List<Warning>? warnings = null;
        List<Error>? errors = null;
        Models.Availabilities.AvailStatusMessages? availStatusMessages = new();

        var availabilityRestrictionRequest = new AvailabilityRestrictionRequest
        {
            SupplierId = Constants.TravelClickId,
            PropertyCode = hotelCode,
            StartDate = DateOnly.FromDateTime(request.DateRange.Start),
            EndDate = DateOnly.FromDateTime(request.DateRange.End),
            RatePlanCodes = request.RatePlanCandidates.Select(rpc => rpc.RatePlanCode).ToList(),
            RoomTypeCodes = request.RoomTypeCandidates.Select(rpc => rpc.RoomTypeCode).ToList()
        };

        var (availabilityRestrictions, errorDetails) = await _availabilityRestrictionService.Get(availabilityRestrictionRequest);

        if (errorDetails is not null)
        {
            errors = errorDetails.Select(ed => ed.ToError()).ToList();
        }
        else
        {
            success = new();
            var availStatusMessageList = availabilityRestrictions.Select(ar => ar.ToAvailStatusMessage())
                .ToList();

            availStatusMessages = new Models.Availabilities.AvailStatusMessages
            {
                HotelCode = hotelCode,
                AvailStatusMessageList = availStatusMessageList
            };
        }

        return new OtaHotelAvailGetRS
        {
            Version = otaHotelAvailGetRQ.Version,
            TimeStamp = _dateTimeOffsetProvider.UtcNow(),
            EchoToken = otaHotelAvailGetRQ.EchoToken,
            Success = success,
            Errors = errors,
            Warnings = warnings,
            AvailStatusMessages = availStatusMessages
        };
    }


    public async Task<OtaHotelAvailNotifRS> Update(OtaHotelAvailNotifRQ otaHotelAvailNotifRQ, CancellationToken cancellationToken)
    {
        var hotelCode = otaHotelAvailNotifRQ.AvailStatusMessages.HotelCode ?? string.Empty;

        var success = new Success();
        List<Warning>? warnings = null;
        List<Error>? errors = null;

        //var propertyId = await _propertyService.GetId(Constants.TravelClickId, hotelCode);
        var availabilityRestrictions = otaHotelAvailNotifRQ.AvailStatusMessages.AvailStatusMessageList.Select(asm => asm.ToAvailabilityRestriction())
            .ToList();

        await _availabilityRestrictionService.Update(Constants.TravelClickId, availabilityRestrictions);

        return new OtaHotelAvailNotifRS
        {
            Version = otaHotelAvailNotifRQ.Version,
            TimeStamp = _dateTimeOffsetProvider.UtcNow(),
            EchoToken = otaHotelAvailNotifRQ.EchoToken,
            Success = success,
            Errors = errors,
            Warnings = warnings
        };
    }


    private readonly IDateTimeOffsetProvider _dateTimeOffsetProvider;
    private readonly IPropertyService _propertyService;
    private readonly IAvailabilityRestrictionService _availabilityRestrictionService;
}

using HappyTravel.Komoro.Common.Infrastructure;
using HappyTravel.Komoro.Common.Services.Availabilities;
using HappyTravel.Komoro.Common.Services.Statics;
using HappyTravel.Komoro.TravelClickChannelManager.Infrastructure;
using HappyTravel.Komoro.TravelClickChannelManager.Infrastructure.Extensions;
using HappyTravel.Komoro.TravelClickChannelManager.Models;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Response;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Enums;

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
        var hotelCode = otaHotelAvailGetRQ.HotelAvailRequests.FirstOrDefault()?.HotelRef?.HotelCode ?? string.Empty;

        Success? success = new();
        List<Warning>? warnings = null;
        List<Error>? errors = null;
        Models.Availabilities.AvailStatusMessages? availStatusMessages = new();
        //var propertyId = await _propertyService.GetId(Constants.TravelClickId, hotelCode);

        var availabilityRestrictions = await _availabilityRestrictionService.Get(Constants.TravelClickId, hotelCode);

        if (false)  // TODO: Need add errors
        {
            success = null;
            errors = new List<Error>
            {
                ErrorHelper.GetError(ErrorWarningTypes.Authentication, ErrorCodes.InvalidHotel)
            };
        }
        else
        {
            var availStatusMessageList = availabilityRestrictions.Select(ar => ar.ToAvailStatusMessage()).ToList();

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
        List<Error>? errors = null;

        var propertyId = await _propertyService.GetId(Constants.TravelClickId, hotelCode);

        throw new NotImplementedException();
    }


    private readonly IDateTimeOffsetProvider _dateTimeOffsetProvider;
    private readonly IPropertyService _propertyService;
    private readonly IAvailabilityRestrictionService _availabilityRestrictionService;
}

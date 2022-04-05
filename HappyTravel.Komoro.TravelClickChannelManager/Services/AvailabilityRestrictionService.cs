using HappyTravel.Komoro.Common.Infrastructure;
using HappyTravel.Komoro.Common.Services;
using HappyTravel.Komoro.TravelClickChannelManager.Models;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Response;
using HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Response;

namespace HappyTravel.Komoro.TravelClickChannelManager.Services;

public class AvailabilityRestrictionService : IAvailabilityRestrictionService
{
    public AvailabilityRestrictionService(IDateTimeOffsetProvider dateTimeOffsetProvider, IPropertyService propertyService)
    {
        _dateTimeOffsetProvider = dateTimeOffsetProvider;
        _propertyService = propertyService;
    }


    public async Task<OtaHotelAvailGetRS> Get(OtaHotelAvailGetRQ otaHotelAvailGetRQ, CancellationToken cancellationToken)
    {
        var hotelCode = otaHotelAvailGetRQ.HotelAvailRequests.FirstOrDefault()?.HotelRef?.HotelCode ?? string.Empty;

        var success = new Success();
        List<Error>? errors = null;
        HotelProducts? hotelProducts = null;
        var propertyId = await _propertyService.GetId(Constants.TravelClickId, hotelCode);

        throw new NotImplementedException();
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
}

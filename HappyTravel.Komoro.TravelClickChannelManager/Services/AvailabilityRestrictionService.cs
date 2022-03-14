using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Response;

namespace HappyTravel.Komoro.TravelClickChannelManager.Services;

public class AvailabilityRestrictionService : IAvailabilityRestrictionService
{
    public Task<OtaHotelAvailGetRS> Get(OtaHotelAvailGetRQ otaHotelAvailGetRQ, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }


    public Task<OtaHotelAvailNotifRS> Update(OtaHotelAvailNotifRQ otaHotelAvailNotifRQ, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

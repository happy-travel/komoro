using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Response;

namespace HappyTravel.Komoro.TravelClickChannelManager.Services;

public class RateService : IRateService
{
    public Task<OtaHotelRatePlanRS> Get(OtaHotelRatePlanRQ otaHotelRatePlanRQ, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }


    public Task<OtaHotelRatePlanNotifRS> Update(OtaHotelRatePlanNotifRQ otaHotelRatePlanNotifRQ, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

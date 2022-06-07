using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Response;

namespace HappyTravel.Komoro.TravelClickChannelManager.Services;

public interface ITravelClickRateService
{
    Task<OtaHotelRatePlanRS> Get(OtaHotelRatePlanRQ otaHotelRatePlanRQ, CancellationToken cancellationToken);
    Task<OtaHotelRatePlanNotifRS> Update(OtaHotelRatePlanNotifRQ otaHotelRatePlanNotifRQ, CancellationToken cancellationToken);
}

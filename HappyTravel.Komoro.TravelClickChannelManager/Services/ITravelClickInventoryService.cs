using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Response;

namespace HappyTravel.Komoro.TravelClickChannelManager.Services;

public interface ITravelClickInventoryService
{
    Task<OtaHotelInvCountRS> Get(OtaHotelInvCountRQ otaHotelInvCountRQ, CancellationToken cancellationToken);
    Task<OtaHotelInvCountNotifRS> Update(OtaHotelInvCountNotifRQ otaHotelInvCountNotifRQ, CancellationToken cancellationToken);
}

using HappyTravel.Komoro.TravelClickChannelManager.Models.Ping;

namespace HappyTravel.Komoro.TravelClickChannelManager.Services;

public interface IPingService
{
    OtaPingRS Ping(OtaPingRQ otaPingRQ);
}

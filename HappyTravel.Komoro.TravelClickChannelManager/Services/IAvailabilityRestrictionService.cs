using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Response;

namespace HappyTravel.Komoro.TravelClickChannelManager.Services;

public interface IAvailabilityRestrictionService
{
    Task<OtaHotelAvailGetRS> Get(OtaHotelAvailGetRQ otaHotelAvailGetRQ, CancellationToken cancellationToken);
    Task<OtaHotelAvailNotifRS> Update(OtaHotelAvailNotifRQ otaHotelAvailNotifRQ, CancellationToken cancellationToken);
}

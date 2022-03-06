using HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Request;
using HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Response;

namespace HappyTravel.Komoro.TravelClickChannelManager.Services;

public interface IHotelProductService
{
    Task<OtaHotelProductRS> Get(OtaHotelProductRQ otaHotelProductRQ, CancellationToken cancellationToken);
}

using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Response;

namespace HappyTravel.Komoro.TravelClickChannelManager.Services;

public class InventoryService : IInventoryService
{
    public Task<OtaHotelInvCountRS> Get(OtaHotelInvCountRQ otaHotelInvCountRQ, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }


    public Task<OtaHotelInvCountNotifRS> Update(OtaHotelInvCountNotifRQ otaHotelInvCountNotifRQ, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

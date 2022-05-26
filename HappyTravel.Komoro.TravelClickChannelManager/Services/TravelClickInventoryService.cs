using HappyTravel.Komoro.TravelClickChannelManager.Models;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Response;

namespace HappyTravel.Komoro.TravelClickChannelManager.Services;

public class TravelClickInventoryService : ITravelClickInventoryService
{
    public Task<OtaHotelInvCountRS> Get(OtaHotelInvCountRQ otaHotelInvCountRQ, CancellationToken cancellationToken)
    {
        var request = otaHotelInvCountRQ.HotelInvCountRequests.Single();
        var hotelCode = request.HotelRef.HotelCode;

        Success? success = null;
        List<Warning>? warnings = null;
        List<Error>? errors = null;


        throw new NotImplementedException();
    }


    public Task<OtaHotelInvCountNotifRS> Update(OtaHotelInvCountNotifRQ otaHotelInvCountNotifRQ, CancellationToken cancellationToken)
    {
        var hotelCode = otaHotelInvCountNotifRQ.Inventories.HotelCode ?? string.Empty;

        Success? success = null;
        List<Warning>? warnings = null;
        List<Error>? errors = null;


        throw new NotImplementedException();
    }
}

using HappyTravel.Komoro.Common.Infrastructure;
using HappyTravel.Komoro.Common.Infrastructure.Extensions;
using HappyTravel.Komoro.Common.Services;
using HappyTravel.Komoro.TravelClickChannelManager.Infrastructure;
using HappyTravel.Komoro.TravelClickChannelManager.Models;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Enums;
using Requests = HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Request;
using Responses = HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Response;

namespace HappyTravel.Komoro.TravelClickChannelManager.Services;

internal class HotelProductService : IHotelProductService
{
    public HotelProductService(IDateTimeOffsetProvider dateTimeOffsetProvider, IRoomService roomService)
    {
        _dateTimeOffsetProvider = dateTimeOffsetProvider;
        _roomService = roomService;
    }


    public async Task<Responses.OtaHotelProductRS> Get(Requests.OtaHotelProductRQ otaHotelProductRQ, CancellationToken cancellationToken)
    {
        var hotelCode = otaHotelProductRQ.HotelProducts.FirstOrDefault()?.HotelCode ?? string.Empty;
        _ = int.TryParse(hotelCode, out var propertyId);
        
        var success = new Success();
        List<Error>? errors = null;
        Responses.HotelProducts? hotelProducts = null;
        var rooms = await _roomService.Get(propertyId, cancellationToken);
        if (rooms.Count == 0)
        {
            success = null;
            errors = new List<Error>
            {
                ErrorHelper.GetError(ErrorWarningTypes.Authentication, ErrorCodes.InvalidHotel)
            };
        }
        else
        {
            var ratePlans = new List<Responses.RatePlan>();
            var roomTypes = new List<Responses.RoomType>();

            hotelProducts = new Responses.HotelProducts
            {
                HotelCode = hotelCode,
                HotelProductList = new List<Responses.HotelProduct>
                {
                    new Responses.HotelProduct
                    {
                        RatePlans = ratePlans,
                        RoomTypes = roomTypes
                    }
                }
            };
        }
            
        return new Responses.OtaHotelProductRS
        {
            Version = otaHotelProductRQ.Version,
            TimeStamp = _dateTimeOffsetProvider.UtcNow(),
            EchoToken = otaHotelProductRQ.EchoToken,
            Success = success,
            Errors = errors,
            HotelProducts = hotelProducts
        };
    }

    
    private readonly IDateTimeOffsetProvider _dateTimeOffsetProvider;
    private readonly IRoomService _roomService;
}

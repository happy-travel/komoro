using HappyTravel.Komoro.Common.Infrastructure;
using HappyTravel.Komoro.Common.Services.Statics;
using HappyTravel.Komoro.TravelClickChannelManager.Infrastructure;
using HappyTravel.Komoro.TravelClickChannelManager.Infrastructure.Extensions;
using HappyTravel.Komoro.TravelClickChannelManager.Models;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Enums;
using Requests = HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Request;
using Responses = HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Response;

namespace HappyTravel.Komoro.TravelClickChannelManager.Services;

internal class HotelProductService : IHotelProductService
{
    public HotelProductService(IDateTimeOffsetProvider dateTimeOffsetProvider, IPropertyService propertyService, IRoomService roomService)
    {
        _dateTimeOffsetProvider = dateTimeOffsetProvider;
        _propertyService = propertyService;
        _roomService = roomService;
    }


    public async Task<Responses.OtaHotelProductRS> Get(Requests.OtaHotelProductRQ otaHotelProductRQ, CancellationToken cancellationToken)
    {
        var hotelCode = otaHotelProductRQ.HotelProducts.FirstOrDefault()?.HotelCode ?? string.Empty;
        
        var success = new Success();
        List<Error>? errors = null;
        Responses.HotelProducts? hotelProducts = null;
        var propertyId = await _propertyService.GetId(Constants.TravelClickCode, hotelCode);
        var rooms = await _roomService.Get(propertyId, cancellationToken);
        if (rooms.Count == 0)
        {
            success = null;
            errors = new List<Error>
            {
                ErrorHelper.GetError(ErrorWarningTypes.Authentication, ErrorCodes.InvalidHotel, hotelCode)
            };
        }
        else
        {
            var hotelProductList = rooms.Select(r => r.ToHotelProduct()).ToList();

            hotelProducts = new Responses.HotelProducts
            {
                HotelCode = hotelCode,
                HotelProductList = hotelProductList
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
    private readonly IPropertyService _propertyService;
    private readonly IRoomService _roomService;
}

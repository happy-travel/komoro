using AspNetCore.Authentication.Basic;
using HappyTravel.Komoro.Common.Controllers;
using HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Request;
using HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Response;
using HappyTravel.Komoro.TravelClickChannelManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyTravel.Komoro.TravelClickChannelManager.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{v:apiVersion}/travel-click/hotel-products")]
[Produces("application/xml")]
[Authorize(AuthenticationSchemes = BasicDefaults.AuthenticationScheme)]
public class HotelProductController : BaseController
{
    public HotelProductController(IHotelProductService hotelProductService)
    {
        _hotelProductService = hotelProductService;
    }


    /// <summary>
    /// Obtains Hotel Products
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(OtaHotelProductRS), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromBody] OtaHotelProductRQ otaHotelProductRQ, CancellationToken cancellationToken)
        => Ok(await _hotelProductService.Get(otaHotelProductRQ, cancellationToken));


    private readonly IHotelProductService _hotelProductService;
}

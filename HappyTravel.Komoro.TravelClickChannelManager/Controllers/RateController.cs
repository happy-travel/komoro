using AspNetCore.Authentication.Basic;
using HappyTravel.Komoro.Common.Controllers;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Response;
using HappyTravel.Komoro.TravelClickChannelManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyTravel.Komoro.TravelClickChannelManager.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{v:apiVersion}/travel-click/rates")]
[Produces("application/xml")]
[Authorize(AuthenticationSchemes = BasicDefaults.AuthenticationScheme)]
public class RateController : BaseController
{
    public RateController(ITravelClickRateService rateService)
    {
        _rateService = rateService;
    }


    /// <summary>
    /// Gets Rates
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(OtaHotelRatePlanRS), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromBody] OtaHotelRatePlanRQ otaHotelRatePlanRQ, CancellationToken cancellationToken)
        => Ok(await _rateService.Get(otaHotelRatePlanRQ, cancellationToken));


    /// <summary>
    /// Updates Rates
    /// </summary>
    [HttpPost("update")]
    [ProducesResponseType(typeof(OtaHotelRatePlanNotifRS), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromBody] OtaHotelRatePlanNotifRQ otaHotelRatePlanNotifRQ, CancellationToken cancellationToken)
        => Ok(await _rateService.Update(otaHotelRatePlanNotifRQ, cancellationToken));


    private readonly ITravelClickRateService _rateService;
}

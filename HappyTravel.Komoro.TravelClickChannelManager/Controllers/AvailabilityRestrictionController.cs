using HappyTravel.Komoro.Common.Controllers;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Response;
using HappyTravel.Komoro.TravelClickChannelManager.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyTravel.Komoro.TravelClickChannelManager.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{v:apiVersion}/travel-click/availability-restrictions")]
[Produces("application/xml")]
public class AvailabilityRestrictionController : BaseController
{
    public AvailabilityRestrictionController(ITravelClickAvailabilityRestrictionService availabilityRestrictionService)
    {
        _availabilityRestrictionService = availabilityRestrictionService;
    }


    /// <summary>
    /// Gets Availability Restrictions
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(OtaHotelAvailGetRS), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromBody] OtaHotelAvailGetRQ otaHotelAvailGetRQ, CancellationToken cancellationToken)
        => Ok(await _availabilityRestrictionService.Get(otaHotelAvailGetRQ, cancellationToken));


    /// <summary>
    /// Updates Availability Restrictions
    /// </summary>
    [HttpPost("update")]
    [ProducesResponseType(typeof(OtaHotelAvailNotifRS), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromBody] OtaHotelAvailNotifRQ otaHotelAvailNotifRQ, CancellationToken cancellationToken)
        => Ok(await _availabilityRestrictionService.Update(otaHotelAvailNotifRQ, cancellationToken));


    private readonly ITravelClickAvailabilityRestrictionService _availabilityRestrictionService;
}

using HappyTravel.Komoro.Common.Controllers;
using HappyTravel.Komoro.TravelClickChannelManager.Models.Ping;
using HappyTravel.Komoro.TravelClickChannelManager.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyTravel.Komoro.TravelClickChannelManager.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{v:apiVersion}/travel-click/ping")]
[Produces("application/xml")]
public class PingController : BaseController
{
    public PingController(IPingService pingService)
    {
        _pingService = pingService;
    }


    /// <summary>
    /// Ping
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(OtaPingRS), StatusCodes.Status200OK)]
    public IActionResult Ping([FromBody] OtaPingRQ otaPingRQ)
        => Ok(_pingService.Ping(otaPingRQ));


    private readonly IPingService _pingService;
}

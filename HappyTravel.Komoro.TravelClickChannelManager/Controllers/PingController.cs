using HappyTravel.Komoro.Common.Controllers;
using HappyTravel.Komoro.TravelClickChannelManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace HappyTravel.Komoro.TravelClickChannelManager.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{v:apiVersion}/travel-click/ping")]
[Produces("application/json")]
public class PingController : BaseController
{
    public PingController(IPingService pingService)
    {
        _pingService = pingService;
    }


    private readonly IPingService _pingService;
}

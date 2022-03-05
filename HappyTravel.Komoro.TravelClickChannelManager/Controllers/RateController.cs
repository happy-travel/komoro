using HappyTravel.Komoro.Common.Controllers;
using HappyTravel.Komoro.TravelClickChannelManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace HappyTravel.Komoro.TravelClickChannelManager.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{v:apiVersion}/travel-click/rates")]
[Produces("application/xml")]
public class RateController : BaseController
{
    public RateController(IRateService rateService)
    {
        _rateService = rateService;
    }


    private readonly IRateService _rateService;
}

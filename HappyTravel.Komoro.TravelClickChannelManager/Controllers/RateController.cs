using HappyTravel.Komoro.Common.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HappyTravel.Komoro.TravelClickChannelManager.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{v:apiVersion}/travel-click/rates")]
[Produces("application/json")]
public class RateController : BaseController
{

}

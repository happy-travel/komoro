using HappyTravel.Komoro.Api.Services.Statics;
using HappyTravel.Komoro.Common.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyTravel.Komoro.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{v:apiVersion}/rate-plans")]
[Produces("application/json")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class RatePlanController : BaseController
{
    public RatePlanController(IRatePlanService ratePlanService)
    {
        _ratePlanService = ratePlanService;
    }


    /// <summary>
    /// Gets a list of all rate plan names
    /// </summary>
    /// <returns>List of rate plan names</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
    public IActionResult Get()
        => Ok(_ratePlanService.Get());


    private readonly IRatePlanService _ratePlanService;
}

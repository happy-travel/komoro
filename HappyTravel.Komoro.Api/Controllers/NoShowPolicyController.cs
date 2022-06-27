using HappyTravel.Komoro.Api.Services.Statics;
using HappyTravel.Komoro.Common.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyTravel.Komoro.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{v:apiVersion}/no-show-policies")]
[Produces("application/json")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class NoShowPolicyController : BaseController
{
    public NoShowPolicyController(INoShowPolicyService noShowPolicyService)
    {
        _noShowPolicyService = noShowPolicyService;
    }


    /// <summary>
    /// Gets a list of all no show policy names
    /// </summary>
    /// <returns>List of no show policy names</returns>
    [HttpGet("")]
    [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
    public IActionResult Get()
        => Ok(_noShowPolicyService.Get());


    private readonly INoShowPolicyService _noShowPolicyService;
}

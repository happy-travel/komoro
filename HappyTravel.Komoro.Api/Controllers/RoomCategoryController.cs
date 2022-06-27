using HappyTravel.Komoro.Api.Services.Statics;
using HappyTravel.Komoro.Common.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyTravel.Komoro.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{v:apiVersion}/room-categories")]
[Produces("application/json")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class RoomCategoryController : BaseController
{
    public RoomCategoryController(IRoomCategoryService roomCategoryService)
    {
        _roomCategoryService = roomCategoryService;
    }


    /// <summary>
    /// Gets a list of all room category names
    /// </summary>
    /// <returns>List of room category names</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
    public IActionResult Get()
        => Ok(_roomCategoryService.Get());


    private readonly IRoomCategoryService _roomCategoryService;
}

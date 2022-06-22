using HappyTravel.Komoro.Api.Services.Statics;
using HappyTravel.Komoro.Common.Controllers;
using HappyTravel.KomoroContracts.Statics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyTravel.Komoro.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{v:apiVersion}/room-types")]
[Produces("application/json")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

public class RoomTypeController : BaseController
{
    public RoomTypeController(IRoomTypeService roomTypeService)
    {
        _roomTypeService = roomTypeService;
    }


    /// <summary>
    /// Gets a list of all room types
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of room types</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<RoomType>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
        => Ok(await _roomTypeService.Get(cancellationToken));


    /// <summary>
    /// Adds a new room type
    /// </summary>
    /// <param name="roomType">Room type data</param>
    /// <param name="cancellationToken">Сancellation token</param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody] RoomType roomType, CancellationToken cancellationToken)
        => NoContentOrBadRequest(await _roomTypeService.Add(roomType, cancellationToken));


    /// <summary>
    /// Modifies an existing room type
    /// </summary>
    /// <param name="roomType">New data for the room type</param>
    /// <param name="cancellationToken">Сancellation token</param>
    /// <param name="roomTypeId">Room type id</param>
    [HttpPut("{roomTypeId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Modify([FromRoute] int roomTypeId, [FromBody] RoomType roomType, CancellationToken cancellationToken)
        => NoContentOrBadRequest(await _roomTypeService.Modify(roomTypeId, roomType, cancellationToken));


    /// <summary>
    /// Removes a room type
    /// </summary>
    /// <param name="roomTypeId">Room type id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    [HttpDelete("{roomTypeId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Remove([FromRoute] int roomTypeId, CancellationToken cancellationToken)
        => NoContentOrBadRequest(await _roomTypeService.Remove(roomTypeId, cancellationToken));


    private readonly IRoomTypeService _roomTypeService;
}

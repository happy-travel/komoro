using HappyTravel.Komoro.Api.Models;
using HappyTravel.Komoro.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HappyTravel.Komoro.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{v:apiVersion}/properties/{propertyId}/rooms")]
[Produces("application/json")]
public class RoomController : BaseController
{
    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }


    /// <summary>
    /// Gets a list of rooms for the specified property
    /// </summary>
    /// <param name="propertyId">Property id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of rooms</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<Room>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromRoute] int propertyId, CancellationToken cancellationToken)
        => Ok(await _roomService.Get(propertyId, cancellationToken));


    /// <summary>
    /// Adds a new room for the specified property
    /// </summary>
    /// <param name="propertyId">Property id</param>
    /// <param name="room">Room data</param>
    /// <param name="cancellationToken">Сancellation token</param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add([FromRoute] int propertyId, [FromBody] Room room, CancellationToken cancellationToken)
        => NoContentOrBadRequest(await _roomService.Add(propertyId, room, cancellationToken));


    /// <summary>
    /// Modifies an existing room for the specified property
    /// </summary>
    /// <param name="propertyId">Property id</param>
    /// <param name="room">New data for the room</param>
    /// <param name="cancellationToken">Сancellation token</param>
    /// <param name="roomId">Room id</param>
    [HttpPut("{roomId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Modify([FromRoute] int propertyId, [FromRoute] int roomId, [FromBody] Room room, CancellationToken cancellationToken)
        => NoContentOrBadRequest(await _roomService.Modify(propertyId, roomId, room, cancellationToken));


    /// <summary>
    /// Removes a room for the specified property
    /// </summary>
    /// <param name="propertyId">Property id</param>
    /// <param name="roomId">Room id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    [HttpDelete("{roomId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Remove([FromRoute] int propertyId, [FromRoute] int roomId, CancellationToken cancellationToken)
        => NoContentOrBadRequest(await _roomService.Remove(propertyId, roomId, cancellationToken));


    private readonly IRoomService _roomService;
}

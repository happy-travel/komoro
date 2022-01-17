using HappyTravel.Komoro.Api.Models;
using HappyTravel.Komoro.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HappyTravel.Komoro.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{v:apiVersion}/properties")]
[Produces("application/json")]
public class PropertyController : BaseController
{
    public PropertyController(IPropertyService accommodationService)
    {
        _accommodationService = accommodationService;
    }


    /// <summary>
    /// Gets a list of all accommodations
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of slim accommodations</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<SlimProperty>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
        => Ok(await _accommodationService.Get(cancellationToken));


    /// <summary>
    /// Gets a accommodation by id
    /// </summary>
    /// <param name="accommodationId">Accommodation id</param>
    /// <param name="cancellationToken">Сancellation token</param>
    /// <returns>The accommodation data</returns>
    [HttpGet("{accommodationId:int}")]
    [ProducesResponseType(typeof(Property), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get([FromRoute] int accommodationId, CancellationToken cancellationToken)
        => OkOrBadRequest(await _accommodationService.Get(accommodationId, cancellationToken));


    /// <summary>
    /// Adds a new accommodation 
    /// </summary>
    /// <param name="richAccommodation">Accommodation data</param>
    /// <param name="cancellationToken">Сancellation token</param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody] Property richAccommodation, CancellationToken cancellationToken)
        => NoContentOrBadRequest(await _accommodationService.Add(richAccommodation, cancellationToken));


    /// <summary>
    /// Modifies an existing accommodation
    /// </summary>
    /// <param name="richSupplier">New data for the accommodation</param>
    /// <param name="cancellationToken">Сancellation token</param>
    /// <param name="accommodationId">Accommodation id</param>
    [HttpPut("{accommodationId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Modify([FromRoute] int accommodationId, [FromBody] Property richSupplier, CancellationToken cancellationToken)
        => NoContentOrBadRequest(await _accommodationService.Modify(accommodationId, richSupplier, cancellationToken));


    /// <summary>
    /// Removes a accommodation
    /// </summary>
    /// <param name="accommodationId">Accommodation id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    [HttpDelete("{accommodationId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Remove([FromRoute] int accommodationId, CancellationToken cancellationToken)
        => NoContentOrBadRequest(await _accommodationService.Remove(accommodationId, cancellationToken));


    private readonly IPropertyService _accommodationService;
}

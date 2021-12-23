﻿using HappyTravel.Komoro.Api.Models;
using HappyTravel.Komoro.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HappyTravel.Komoro.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{v:apiVersion}/accommodations")]
[Produces("application/json")]
public class AccommodationController : BaseController
{
    public AccommodationController(IAccommodationService accommodationService)
    {
        _accommodationService = accommodationService;
    }


    /// <summary>
    /// Gets a list of all accommodations
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of slim accommodations</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<SlimAccommodation>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
        => Ok(await _accommodationService.Get(cancellationToken));


    /// <summary>
    /// Gets a accommodation by id
    /// </summary>
    /// <param name="accommodationId">Accommodation id</param>
    /// <param name="cancellationToken">Сancellation token</param>
    /// <returns>The accommodation data</returns>
    [HttpGet("{accommodationId:int}")]
    [ProducesResponseType(typeof(RichAccommodation), StatusCodes.Status200OK)]
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
    public async Task<IActionResult> Add([FromBody] RichAccommodation richAccommodation, CancellationToken cancellationToken)
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
    public async Task<IActionResult> Modify([FromRoute] int accommodationId, [FromBody] RichAccommodation richSupplier, CancellationToken cancellationToken)
        => NoContentOrBadRequest(await _accommodationService.Modify(accommodationId, richSupplier, cancellationToken));


    /// <summary>
    /// Deletes a accommodation
    /// </summary>
    /// <param name="accommodationId">Accommodation id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    [HttpDelete("{accommodationId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete([FromRoute] int accommodationId, CancellationToken cancellationToken)
        => NoContentOrBadRequest(await _accommodationService.Delete(accommodationId, cancellationToken));


    private readonly IAccommodationService _accommodationService;
}

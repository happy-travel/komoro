using HappyTravel.KomoroContracts.Statics;
using HappyTravel.Komoro.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HappyTravel.Komoro.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{v:apiVersion}/properties")]
[Produces("application/json")]
public class PropertyController : BaseController
{
    public PropertyController(IPropertyService propertyService)
    {
        _propertyService = propertyService;
    }


    /// <summary>
    /// Gets a list of all properties
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of slim properties</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<SlimProperty>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
        => Ok(await _propertyService.Get(cancellationToken));


    /// <summary>
    /// Gets a property by id
    /// </summary>
    /// <param name="propertyId">Property id</param>
    /// <param name="cancellationToken">Сancellation token</param>
    /// <returns>The property data</returns>
    [HttpGet("{propertyId:int}")]
    [ProducesResponseType(typeof(Property), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get([FromRoute] int propertyId, CancellationToken cancellationToken)
        => OkOrBadRequest(await _propertyService.Get(propertyId, cancellationToken));


    /// <summary>
    /// Adds a new property 
    /// </summary>
    /// <param name="property">Property data</param>
    /// <param name="cancellationToken">Сancellation token</param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody] Property property, CancellationToken cancellationToken)
        => NoContentOrBadRequest(await _propertyService.Add(property, cancellationToken));


    /// <summary>
    /// Modifies an existing property
    /// </summary>
    /// <param name="property">New data for the property</param>
    /// <param name="cancellationToken">Сancellation token</param>
    /// <param name="propertyId">Property id</param>
    [HttpPut("{propertyId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Modify([FromRoute] int propertyId, [FromBody] Property property, CancellationToken cancellationToken)
        => NoContentOrBadRequest(await _propertyService.Modify(propertyId, property, cancellationToken));


    /// <summary>
    /// Removes a property
    /// </summary>
    /// <param name="propertyId">Property id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    [HttpDelete("{propertyId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Remove([FromRoute] int propertyId, CancellationToken cancellationToken)
        => NoContentOrBadRequest(await _propertyService.Remove(propertyId, cancellationToken));


    /// <summary>
    /// Uploading hotel data from a CSV file for a TravelClick supplier
    /// </summary>
    /// <param name="propertyId">Property id to update an existing property or 0 to add a new one</param>
    /// <param name="uploadedFile">CSV file to loading</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    [HttpPost("{propertyId:int}/travel-click/upload")]
    [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UploadTravelClickProperty([FromRoute] int propertyId, [FromForm] IFormFile uploadedFile, CancellationToken cancellationToken)
        => NoContentOrBadRequest(await _propertyService.UploadTravelClickProperty(propertyId, uploadedFile, cancellationToken));


    private readonly IPropertyService _propertyService;
}

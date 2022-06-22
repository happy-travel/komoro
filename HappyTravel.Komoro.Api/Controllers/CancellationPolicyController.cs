using HappyTravel.Komoro.Api.Services.Statics;
using HappyTravel.Komoro.Common.Controllers;
using HappyTravel.KomoroContracts.Statics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyTravel.Komoro.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{v:apiVersion}/properties/{propertyId}/cancellation-policies")]
[Produces("application/json")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class CancellationPolicyController : BaseController
{
    public CancellationPolicyController(ICancellationPolicyService cancellationPolicyService)
    {
        _cancellationPolicyService = cancellationPolicyService;
    }


    /// <summary>
    /// Gets a list of cancellation policies for the specified property
    /// </summary>
    /// <param name="propertyId">Property id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of cancellation policies</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<CancellationPolicy>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromRoute] int propertyId, CancellationToken cancellationToken)
        => Ok(await _cancellationPolicyService.Get(propertyId, cancellationToken));


    /// <summary>
    /// Adds a new cancellation policy for the specified property
    /// </summary>
    /// <param name="propertyId">Property id</param>
    /// <param name="cancellationPolicy">Cancellation policy data</param>
    /// <param name="cancellationToken">Сancellation token</param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add([FromRoute] int propertyId, [FromBody] CancellationPolicy cancellationPolicy, CancellationToken cancellationToken)
        => NoContentOrBadRequest(await _cancellationPolicyService.Add(propertyId, cancellationPolicy, cancellationToken));


    /// <summary>
    /// Modifies an existing cancellation policy for the specified property
    /// </summary>
    /// <param name="propertyId">Property id</param>
    /// <param name="cancellationPolicy">New data for the cancellation policy</param>
    /// <param name="cancellationToken">Сancellation token</param>
    /// <param name="cancellationPolicyId">Cancellation policy id</param>
    [HttpPut("{cancellationPolicyId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Modify([FromRoute] int propertyId, [FromRoute] int cancellationPolicyId, [FromBody] CancellationPolicy cancellationPolicy, 
        CancellationToken cancellationToken)
        => NoContentOrBadRequest(await _cancellationPolicyService.Modify(propertyId, cancellationPolicyId, cancellationPolicy, cancellationToken));


    /// <summary>
    /// Removes a cancellation policy for the specified property
    /// </summary>
    /// <param name="propertyId">Property id</param>
    /// <param name="cancellationPolicyId">Cancellation policy id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    [HttpDelete("{cancellationPolicyId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Remove([FromRoute] int propertyId, [FromRoute] int cancellationPolicyId, CancellationToken cancellationToken)
        => NoContentOrBadRequest(await _cancellationPolicyService.Remove(propertyId, cancellationPolicyId, cancellationToken));


    private readonly ICancellationPolicyService _cancellationPolicyService;
}

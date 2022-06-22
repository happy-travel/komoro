using HappyTravel.Komoro.Api.Services.Statics;
using HappyTravel.Komoro.Common.Controllers;
using HappyTravel.KomoroContracts.Statics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyTravel.Komoro.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{v:apiVersion}/countries")]
[Produces("application/json")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

public class CountryController : BaseController
{
    public CountryController(ICountryService countryService)
    {
        _countryService = countryService;
    }


    /// <summary>
    /// Gets a list of all countries
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of countries</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<Country>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
        => Ok(await _countryService.Get(cancellationToken));


    /// <summary>
    /// Adds a new country
    /// </summary>
    /// <param name="country">Country data</param>
    /// <param name="cancellationToken">Сancellation token</param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody] Country country, CancellationToken cancellationToken)
        => NoContentOrBadRequest(await _countryService.Add(country, cancellationToken));


    /// <summary>
    /// Modifies an existing country
    /// </summary>
    /// <param name="country">New data for the country</param>
    /// <param name="cancellationToken">Сancellation token</param>
    /// <param name="countryId">Country id</param>
    [HttpPut("{countryId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Modify([FromRoute] int countryId, [FromBody] Country country, CancellationToken cancellationToken)
        => NoContentOrBadRequest(await _countryService.Modify(countryId, country, cancellationToken));


    /// <summary>
    /// Removes a country
    /// </summary>
    /// <param name="countryId">Country id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    [HttpDelete("{countryId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Remove([FromRoute] int countryId, CancellationToken cancellationToken)
        => NoContentOrBadRequest(await _countryService.Remove(countryId, cancellationToken));


    private readonly ICountryService _countryService;
}

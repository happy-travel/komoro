using HappyTravel.KomoroContracts.Statics;
using HappyTravel.Komoro.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HappyTravel.Komoro.Common.Controllers;

namespace HappyTravel.Komoro.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{v:apiVersion}/meal-plans")]
[Produces("application/json")]
[Authorize]
public class MealPlanController : BaseController
{
    public MealPlanController(IMealPlanService mealPlanService)
    {
        _mealPlanService = mealPlanService;
    }


    /// <summary>
    /// Gets a list of all meal plans
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of meal plans</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<MealPlan>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
        => Ok(await _mealPlanService.Get(cancellationToken));


    /// <summary>
    /// Adds a new meal plan
    /// </summary>
    /// <param name="mealPlan">Meal plan data</param>
    /// <param name="cancellationToken">Сancellation token</param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody] MealPlan mealPlan, CancellationToken cancellationToken)
        => NoContentOrBadRequest(await _mealPlanService.Add(mealPlan, cancellationToken));


    /// <summary>
    /// Modifies an existing meal plan
    /// </summary>
    /// <param name="mealPlan">New data for the meal plan</param>
    /// <param name="cancellationToken">Сancellation token</param>
    /// <param name="mealPlanId">Meal plan id</param>
    [HttpPut("{mealPlanId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Modify([FromRoute] int mealPlanId, [FromBody] MealPlan mealPlan, CancellationToken cancellationToken)
        => NoContentOrBadRequest(await _mealPlanService.Modify(mealPlanId, mealPlan, cancellationToken));


    /// <summary>
    /// Removes a meal plan
    /// </summary>
    /// <param name="mealPlanId">Meal plan id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    [HttpDelete("{mealPlanId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Remove([FromRoute] int mealPlanId, CancellationToken cancellationToken)
        => NoContentOrBadRequest(await _mealPlanService.Remove(mealPlanId, cancellationToken));


    private readonly IMealPlanService _mealPlanService;
}

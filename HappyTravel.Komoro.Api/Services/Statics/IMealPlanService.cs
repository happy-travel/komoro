using CSharpFunctionalExtensions;
using HappyTravel.KomoroContracts.Statics;

namespace HappyTravel.Komoro.Api.Services.Statics;

public interface IMealPlanService
{
    Task<List<MealPlan>> Get(CancellationToken cancellationToken);
    Task<Result> Add(MealPlan mealPlan, CancellationToken cancellationToken);
    Task<Result> Modify(int mealPlanId, MealPlan mealPlan, CancellationToken cancellationToken);
    Task<Result> Remove(int mealPlanId, CancellationToken cancellationToken);
}

using CSharpFunctionalExtensions;
using HappyTravel.Komoro.Api.Models;

namespace HappyTravel.Komoro.Api.Services;

public interface IMealPlanService
{
    Task<List<MealPlan>> Get(CancellationToken cancellationToken);
    Task<Result> Add(MealPlan mealPlan, CancellationToken cancellationToken);
    Task<Result> Modify(int mealPlanId, MealPlan mealPlan, CancellationToken cancellationToken);
    Task<Result> Remove(int mealPlanId, CancellationToken cancellationToken);
}

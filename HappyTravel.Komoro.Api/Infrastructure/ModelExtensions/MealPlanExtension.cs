using ApiModels = HappyTravel.Komoro.Api.Models;
using DataModels = HappyTravel.Komoro.Data.Models.Statics;

namespace HappyTravel.Komoro.Api.Infrastructure.ModelExtensions;

public static class MealPlanExtension
{
    public static ApiModels.MealPlan ToApiMealPlan(this DataModels.MealPlan mealPlan)
    {
        return new ApiModels.MealPlan
        {
            Id = mealPlan.Id,
            Name = mealPlan.Name
        };
    }
}

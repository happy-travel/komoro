using ApiModels = HappyTravel.KomoroContracts.Statics;
using DataModels = HappyTravel.Komoro.Data.Models.Statics;

namespace HappyTravel.Komoro.Api.Infrastructure.ModelExtensions.Statics;

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

using ApiModels = HappyTravel.Komoro.Api.Models;
using DataModels = HappyTravel.Komoro.Data.Models.Statics;

namespace HappyTravel.Komoro.Api.Infrastructure.ModelExtensions;

public static class RoomExtension
{
    public static ApiModels.Room ToApiRoom(this DataModels.Room room, DataModels.MealPlan mealPlan, DataModels.RoomType roomType)
    {
        return new ApiModels.Room
        {
            Id = room.Id,
            PropertyId = room.PropertyId,
            RoomType = roomType.ToApiRoomType(),
            StandardMealPlan = mealPlan.ToApiMealPlan(),
            StandardOccupancy = room.StandardOccupancy,
            MaximumOccupancy = room.MaximumOccupancy,
            ExtraAdultSupplement = room.ExtraAdultSupplement,
            ChildSupplement = room.ChildSupplement,
            InfantSupplement = room.InfantSupplement,
            RatePlans = room.RatePlans,
        };
    }
}

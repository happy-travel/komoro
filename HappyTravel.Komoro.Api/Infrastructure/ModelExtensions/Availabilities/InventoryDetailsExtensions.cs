using ApiModels = HappyTravel.KomoroContracts.Availabilities;
using DataModels = HappyTravel.Komoro.Data.Models.Availabilities;

namespace HappyTravel.Komoro.Api.Infrastructure.ModelExtensions.Availabilities;

public static class InventoryDetailsExtensions
{
    public static ApiModels.InventoryDetails ToApiInventoryDetails(this DataModels.Inventory inventory)
    {
        return new ApiModels.InventoryDetails
        {
            StartDate = inventory.StartDate,
            EndDate = inventory.EndDate,
            RoomTypeCode = inventory.RoomType.Code,
            RatePlanCode = inventory.RatePlanCode,
            NumberOfAvailableRooms = inventory.NumberOfAvailableRooms,
            NumberOfBookedRooms = inventory.NumberOfBookedRooms
        };
    }
}

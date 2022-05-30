using HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities;
using HappyTravel.KomoroContracts.Availabilities;

namespace HappyTravel.Komoro.TravelClickChannelManager.Infrastructure.Extensions;

public static class InventoryExtensions
{
    public static Models.Availabilities.Inventory ToInventory(this InventoryDetails inventoryDetails)
    {
        return new Models.Availabilities.Inventory
        {
            StatusApplicationControl = new StatusApplicationControl
            {
                Start = inventoryDetails.StartDate.ToDateTime(TimeOnly.MinValue),
                End = inventoryDetails.EndDate.ToDateTime(TimeOnly.MinValue),
                InvTypeCode = inventoryDetails.RoomTypeCode,
                RatePlanCode = inventoryDetails.RatePlanCode
            },
            InvCounts = new List<InvCount>
            {
                new InvCount
                {
                    CountType = AvailableRoom,
                    Count = inventoryDetails.NumberOfAvailableRooms
                },
                new InvCount
                {
                    CountType = BookedRoom,
                    Count = inventoryDetails.NumberOfBookedRooms ?? 0
                }
            }
        };
    }


    public static InventoryDetails ToInventoryDetails(this Models.Availabilities.Inventory inventory)
    {
        return new InventoryDetails
        {
            StartDate = DateOnly.FromDateTime(inventory.StatusApplicationControl.Start),
            EndDate = DateOnly.FromDateTime(inventory.StatusApplicationControl.End),
            RatePlanCode = inventory.StatusApplicationControl.RatePlanCode,
            RoomTypeCode = inventory.StatusApplicationControl.InvTypeCode,
            NumberOfAvailableRooms = inventory.InvCounts.Single(ic => ic.CountType == AvailableRoom).Count
        };
    }


    private const string AvailableRoom = "2";
    private const string BookedRoom = "4";
}

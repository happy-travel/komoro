using HappyTravel.Money.Models;

namespace HappyTravel.Komoro.Data.Models.Statics;

public class Room
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public int RoomTypeId { get; set; }
    public int StandardMealPlanId { get; set; }
    public Occupancy StandardOccupancy { get; set; } = null!;
    public List<Occupancy> MaximumOccupancy { get; set; } = null!;
    public MoneyAmount? ExtraAdultSupplement { get; set; }
    public MoneyAmount? ChildSupplement { get; set; }
    public MoneyAmount? InfantSupplement { get; set; }
    public RatePlans RatePlans { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime? Modified { get; set; }
}

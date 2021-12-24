using HappyTravel.Money.Models;

namespace HappyTravel.Komoro.Data.Models.Statics;

public class Room
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public RoomType Type { get; set; } = null!;
    public MealPlan StandardMealPlan { get; set; } = null!;
    public Occupancy StandardOccupancy { get; set; } = null!;
    public List<Occupancy> MaximumOccupancy { get; set; } = null!;
    public MoneyAmount? ExtraAdultSupplement { get; set; }
    public MoneyAmount? ChildSupplement { get; set; } = null!;
    public MoneyAmount? InfantSupplement { get; set; } = null!;
    public RatePlanSettings RatePlans { get; set; } = null!;
}

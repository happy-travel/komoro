namespace HappyTravel.Komoro.Data.Models.Statics;

public class MealPlan
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? Modified { get; set; }
}

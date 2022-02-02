using HappyTravel.KomoroContracts.Enums;

namespace HappyTravel.Komoro.Data.Models.Statics;

public class RoomType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public RoomCategories Category { get; set; }
    public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset Modified { get; set; }
}

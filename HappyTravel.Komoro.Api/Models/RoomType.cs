using HappyTravel.Komoro.Data.Models.Statics;

namespace HappyTravel.Komoro.Api.Models
{
    public record RoomType
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public RoomCategories Category { get; init; }
    }
}
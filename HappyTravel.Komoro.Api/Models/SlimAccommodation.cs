namespace HappyTravel.Komoro.Api.Models;

public record SlimAccommodation
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
}

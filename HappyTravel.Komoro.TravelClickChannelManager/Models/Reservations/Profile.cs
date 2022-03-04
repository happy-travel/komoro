namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations;

/// <summary>
/// Profile
/// </summary>
public record Profile
{
    /// <summary>
    /// Customer
    /// </summary>
    public Customer Customer { get; init; } = new();
}

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations;

/// <summary>
/// Guarantee
/// </summary>
public record Guarantee
{
    /// <summary>
    /// List of accepted guaratees
    /// </summary>
    public GuaranteesAccepted GuaranteesAccepted { get; init; } = new();
}

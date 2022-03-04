namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations;

/// <summary>
/// Profiles
/// </summary>
public record Profiles
{
    /// <summary>
    /// Profile info
    /// </summary>
    public ProfileInfo ProfileInfo { get; init; } = new();
}

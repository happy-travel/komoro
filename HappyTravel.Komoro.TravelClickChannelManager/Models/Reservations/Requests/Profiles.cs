namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations.Requests;

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

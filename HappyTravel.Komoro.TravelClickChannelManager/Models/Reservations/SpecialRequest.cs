namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations;

/// <summary>
/// Special request for this guest
/// </summary>
public record SpecialRequest
{
    /// <summary>
    /// Special request description
    /// </summary>
    public string Text { get; init; } = string.Empty;
}

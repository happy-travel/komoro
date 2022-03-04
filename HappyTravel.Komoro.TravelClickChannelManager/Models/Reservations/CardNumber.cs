namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations;

/// <summary>
/// Card number
/// </summary>
public record CardNumber
{
    /// <summary>
    /// Card number in plain text
    /// </summary>
    public string PlainText { get; init; } = string.Empty;
}

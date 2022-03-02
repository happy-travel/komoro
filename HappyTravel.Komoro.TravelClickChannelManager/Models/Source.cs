namespace HappyTravel.Komoro.TravelClickChannelManager.Models;

/// <summary>
/// Source
/// </summary>
public record Source
{
    /// <summary>
    /// Booking channel
    /// </summary>
    public BookingChannel BookingChannel { get; init; } = new();
}

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;

/// <summary>
/// Availability status message
/// </summary>
public record AvailStatusMessage
{
    /// <summary>
    /// Specifies date range and product to which the restrictions should be applied
    /// </summary>
    public StatusApplicationControl StatusApplicationControl { get; init; } = null!;

    /// <summary>
    /// Contains length of stay restrictions
    /// </summary>
    public LengthsOfStay? LengthsOfStay { get; init; }

    /// <summary>
    /// Contains restriction details
    /// </summary>
    public RestrictionStatus? RestrictionStatus { get; init; }
}

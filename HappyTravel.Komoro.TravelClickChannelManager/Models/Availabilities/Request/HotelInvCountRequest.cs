namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;

/// <summary>
/// Hotel inventory count request
/// </summary>
public record HotelInvCountRequest
{
    /// <summary>
    /// Contains the date range that the returned inventory data must cover
    /// </summary>
    public DateRange DateRange { get; init; } = new();

    /// <summary>
    /// Room type candidates
    /// </summary>
    public List<RoomTypeCandidate> RoomTypeCandidates { get; init; } = null!;

    /// <summary>
    /// Hotel reference
    /// </summary>
    public HotelRef HotelRef { get; init; } = new();
}

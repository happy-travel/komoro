namespace HappyTravel.Komoro.TravelLineChannelManager.Models.Availability;

/// <summary>
/// UpdateActionRQ request content
/// </summary>
internal class UpdateActionRQData
{
    /// <summary>
    /// Channel host ID. This channel ID is reported to the host and the channel manager during the connection phase of the host
    /// </summary>
    public string HotelId { get; init; } = string.Empty;

    /// <summary>
    /// Array of updates to be made in the channel
    /// </summary>
    public List<Update> Updates { get; init; } = null!;
}

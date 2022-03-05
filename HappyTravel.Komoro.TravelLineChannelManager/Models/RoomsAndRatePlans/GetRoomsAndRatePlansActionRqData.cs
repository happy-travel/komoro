namespace HappyTravel.Komoro.TravelLineChannelManager.Models.RoomsAndRatePlans;

/// <summary>
/// Get rooms and rate plans action request content
/// </summary>
internal record GetRoomsAndRatePlansActionRqData
{
    /// <summary>
    /// Channel host ID. This channel ID is reported to the host and the channel manager during the connection phase of the host
    /// </summary>
    public string HotelId { get; init; } = string.Empty;
}

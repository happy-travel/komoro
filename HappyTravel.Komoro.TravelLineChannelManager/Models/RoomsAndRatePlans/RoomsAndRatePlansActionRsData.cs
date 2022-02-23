namespace HappyTravel.Komoro.TravelLineChannelManager.Models.RoomsAndRatePlans;

/// <summary>
/// Get rooms and rate plans action response content
/// </summary>
internal record RoomsAndRatePlansActionRsData
{
    /// <summary>
    /// Channel host ID. This channel ID is reported to the host and the channel manager during the connection phase of the host
    /// </summary>
    public string HotelId { get; init; } = string.Empty;

    /// <summary>
    /// List of room categories and corresponding tariff plans
    /// </summary>
    public List<RoomAndRatePlans> RoomsAndRatePlans { get; init; } = null!;
}

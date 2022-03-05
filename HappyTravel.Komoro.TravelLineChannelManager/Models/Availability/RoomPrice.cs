namespace HappyTravel.Komoro.TravelLineChannelManager.Models.Availability;

/// <summary>
/// Price for category rooms
/// </summary>
internal record RoomPrice
{
    /// <summary>
    /// Placement type ID. Required one of the accommodation type identifiers returned by the GetRoomsAndRatePlansAction function
    /// </summary>
    public string Code { get; init; } = string.Empty;

    /// <summary>
    /// The daily price of the room for this type of accommodation within the tariff plan. Each number can be sold under several tariff plans. 
    /// Prices can be uploaded from the hotel PMS automatically, or entered manually by the user in the personal account of the channel manager.
    /// </summary>
    public decimal Price { get; init; }
}

namespace HappyTravel.Komoro.TravelLineChannelManager.Models.Bookings;

/// <summary>
/// Room category
/// </summary>
internal record RoomStay
{
    /// <summary>
    /// Room category identifier. Must be one of the room category identifiers sent by the GetRoomsAndRatePlansAction function
    /// </summary>
    public string RoomTypeId { get; init; } = string.Empty;

    /// <summary>
    /// Rate plan ID. Must be one of the rate identifiers sent by the GetRoomsAndRatePlansAction function
    /// </summary>
    public string RatePlanId { get; init; } = string.Empty;

    /// <summary>
    /// Guest data array
    /// </summary>
    public List<Guest> Guests { get; init; } = null!;

    /// <summary>
    /// Number of adult guests entering the room
    /// </summary>
    public int Adults { get; init; }

    /// <summary>
    /// Number of children in the room
    /// </summary>
    public int Children { get; init; }

    /// <summary>
    /// The absolute value of the commission in the currencyCode, which the host must pay to the channel. The channel manager indicates this information
    /// on the confirmation sent to the host.
    /// </summary>
    public decimal Commission { get; init; }

    /// <summary>
    /// An array containing daily prices. The price for each day of stay must be indicated. If there is no daily price on the channel side, 
    /// it is necessary to divide the total price by the number of days of stay and transfer the corresponding value for each day
    /// </summary>
    public List<BookingPerDayPrice> BookingPerDayPrices { get; init; } = null!;

    /// <summary>
    /// An array containing the total cost of the booking (optional parameter)
    /// </summary>
    public Total? Total { get; init; }
}

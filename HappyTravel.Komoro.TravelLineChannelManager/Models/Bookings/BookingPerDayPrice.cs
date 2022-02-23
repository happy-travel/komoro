namespace HappyTravel.Komoro.TravelLineChannelManager.Models.Bookings;

/// <summary>
/// Daily price for booking
/// </summary>
internal record BookingPerDayPrice
{
    /// <summary>
    /// Date of residence
    /// </summary>
    public DateOnly DateYmd { get; init; }

    /// <summary>
    /// The price for the date of stay in the currency specified in the currencyCode. The price must have a maximum of two decimal places
    /// </summary>
    public decimal Price { get; init; }
}

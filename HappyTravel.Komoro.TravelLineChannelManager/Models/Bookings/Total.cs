namespace HappyTravel.Komoro.TravelLineChannelManager.Models.Bookings;

/// <summary>
/// Element of the total cost of the reservation
/// </summary>
internal record Total
{
    /// <summary>
    /// The total price for the booking indicated in the currency specified in the currencyCode. The price must have a maximum of two decimal places
    /// </summary>
    public decimal AmountAfterTaxes { get; init; }
}

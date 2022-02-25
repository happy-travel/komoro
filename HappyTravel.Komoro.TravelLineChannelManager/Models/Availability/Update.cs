namespace HappyTravel.Komoro.TravelLineChannelManager.Models.Availability;

/// <summary>
/// Update to be made in the channel
/// </summary>
internal record Update
{
    /// <summary>
    /// Date from which to apply the update
    /// </summary>
    public DateOnly StartDateYmd { get; init; }

    /// <summary>
    /// Date by which this update must be applied
    /// </summary>
    public DateOnly EndDateYmd { get; init; }

    /// <summary>
    /// ID of the room category to apply the update to. Required one of the identifiers returned by the GetRoomsAndRatePlansAction function
    /// </summary>
    public string RoomTypeId { get; init; } = string.Empty;

    /// <summary>
    /// The ID of the billing plan to apply the update to. Required one of the identifiers returned by the GetRoomsAndRatePlansAction function
    /// </summary>
    public string RatePlanId { get; init; } = string.Empty;

    /// <summary>
    /// Availability of category rooms (quota). It is set and transmitted only at the room category level and can be specified as a non-negative integer. 
    /// The parameter may be omitted if it has been sent and acknowledged before.
    /// </summary>
    public string Quota { get; init; } = string.Empty;

    /// <summary>
    /// Currency code. In the channel manager system, the currency code is the same within the tariff plan and takes one of the following values: 
    /// AMD, AZN, BGN, BYN, CAD, CHF, CNY, EUR, GBR, INR, KGS, KRW, KZT, MDL, NOK, PLN, RUB , TJS, UAN, USD, UZS.
    /// The currency code on the channel side and in the channel manager system for each tariff plan must be identical.If the currency code is different 
    /// when trying to update, an error is expected from the channel.
    /// </summary>
    public CurrencyCodes CurrencyCode { get; init; }

    /// <summary>
    /// Array of prices for category rooms. The array contains prices for different types of accommodation (single, double, etc.). The parameter 
    /// may be omitted if it has been sent and acknowledged before.
    /// </summary>
    public List<RoomPrice> Prices { get; init; } = null!;

    /// <summary>
    /// Closing room category sales. The parameter may be omitted if it has been sent and acknowledged before.
    /// </summary>
    public bool Closed { get; init; }
}

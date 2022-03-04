namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations.Requests;

/// <summary>
/// Guest mailing address
/// </summary>
public record Address
{
    /// <summary>
    /// Street address
    /// </summary>
    public string AddressLine { get; init; } = string.Empty;

    /// <summary>
    /// City
    /// </summary>
    public string CityName { get; init; } = string.Empty;

    /// <summary>
    /// State/Province
    /// </summary>
    public string StateProv { get; init; } = string.Empty;

    /// <summary>
    /// Country, preferably the ISO Alpha-2 (2 character) country code
    /// </summary>
    public string CountryName { get; init; } = string.Empty;

    /// <summary>
    /// Postal/ZIP code
    /// </summary>
    public string PostalCode { get; init; } = string.Empty;
}

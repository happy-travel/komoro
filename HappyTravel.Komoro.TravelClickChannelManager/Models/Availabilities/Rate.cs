using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities;

/// <summary>
/// Rate
/// </summary>
public record Rate
{
    /// <summary>
    /// Room identifier
    /// </summary>
    [XmlAttribute]
    public string InvTypeCode { get; init; } = string.Empty;

    /// <summary>
    /// ISO 4217 currency code
    /// </summary>
    [XmlAttribute]
    public string CurrencyCode { get; init; } = string.Empty;

    /// <summary>
    /// List of base rates
    /// </summary>
    public List<BaseByGuestAmt>? BaseByGuestAmts { get; init; }

    /// <summary>
    /// List of additional guest amounts
    /// </summary>
    public List<AdditionalGuestAmount>? AdditionalGuestAmounts { get; init; }
}

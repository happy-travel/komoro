using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations;

/// <summary>
/// Total price of the given room stay. This is not necessarily the total price of the entire reservation (such as when a reservation contains
/// multiple RoomStay elements).
/// </summary>
public record Total
{
    /// <summary>
    /// ISO 4217 currency code
    /// </summary>
    [XmlAttribute]
    public string CurrencyCode { get; init; } = string.Empty;

    /// <summary>
    /// Total price BEFORE tax. Either this or @AmountAfterTax are needed, but it is not necessary to include both.
    /// </summary>
    [XmlAttribute]
    public decimal AmountBeforeTax { get; init; }

    /// <summary>
    /// Total price AFTER tax. Either this or @AmountBeforeTax are needed, but it is not necessary to include both.
    /// </summary>
    [XmlAttribute]
    public decimal AmountAfterTax { get; init; }
}

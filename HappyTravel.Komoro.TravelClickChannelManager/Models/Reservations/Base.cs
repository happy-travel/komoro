using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations;

/// <summary>
/// Rate base
/// </summary>
public record Base
{
    /// <summary>
    /// Base price before tax. Either this or @AmountAfterTax are needed, but it is not necessary to include both.
    /// </summary>
    [XmlAttribute]
    public decimal AmountBeforeTax { get; init; }

    /// <summary>
    /// Base price after tax. Either this or @AmountBeforeTax are needed, but it is not necessary to include both.
    /// </summary>
    [XmlAttribute]
    public decimal AmountAfterTax { get; init; }
}

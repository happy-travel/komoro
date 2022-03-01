using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Response;

public class RatePlan
{
    /// <summary>
    /// Rate plan identifier
    /// </summary>
    [XmlAttribute]
    public string RatePlanCode { get; set; } = string.Empty;

    /// <summary>
    /// Rate plan name
    /// </summary>
    [XmlAttribute]
    public string RatePlanName { get; set; } = string.Empty;

    /// <summary>
    /// Integer. Number of occupants that corresponds with the “base rate” of this room. This can be omitted if occupancy is not relevant.
    /// </summary>
    [XmlAttribute]
    public int? BaseOccupancy { get; set; }

    /// <summary>
    /// ISO 4217 currency code that rate messages are expected to use when applied to products under this rate plan
    /// </summary>
    [XmlAttribute]
    public string CurrencyCode { get; set; } = string.Empty;
}

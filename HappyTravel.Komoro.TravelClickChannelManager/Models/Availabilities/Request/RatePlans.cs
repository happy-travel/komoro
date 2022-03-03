using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;

/// <summary>
/// List of affected rate plans for the given hotel
/// </summary>
[XmlType(TypeName = "RatePlans")]
public record RatePlans
{
    /// <summary>
    /// Hotel identifier
    /// </summary>
    [XmlAttribute]
    public string HotelCode { get; init; } = string.Empty;

    /// <summary>
    /// Rate plan and date range details
    /// </summary>
    [XmlElement(ElementName = "RatePlan")]
    public List<RatePlan> PatePlanList { get; init; } = null!;
}

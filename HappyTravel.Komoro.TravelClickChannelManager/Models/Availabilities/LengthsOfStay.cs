using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities;

/// <summary>
/// Contains length of stay restrictions
/// </summary>
[XmlType(TypeName = "LengthsOfStay")]
public record LengthsOfStay
{
    /// <summary>
    /// Boolean. Optional flag to indicate if the specified length of stay restrictions are based on arrival date. "true" indicates that the restrictions
    /// are arrival date based. A value of "false" or the absense of this attribute indicates that the restrictions are stay through based.
    /// </summary>
    [XmlAttribute]
    public bool ArrivalDateBased { get; init; }

    /// <summary>
    /// Length of stay restriction details
    /// </summary>
    [XmlElement(ElementName = "LengthOfStay")]
    public List<LengthOfStay> LengthOfStayList { get; init; } = null!;
}

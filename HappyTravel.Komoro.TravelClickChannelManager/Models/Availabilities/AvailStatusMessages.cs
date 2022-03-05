using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities;

/// <summary>
/// List of availability status messages for the given hotel
/// </summary>
[XmlType(TypeName = "AvailStatusMessages")]
public record AvailStatusMessages
{
    /// <summary>
    /// Hotel identifier
    /// </summary>
    [XmlAttribute]
    public string HotelCode { get; init; } = string.Empty;

    [XmlElement(ElementName = "AvailStatusMessage")]
    public List<AvailStatusMessage> AvailStatusMessageList { get; init; } = null!;
}

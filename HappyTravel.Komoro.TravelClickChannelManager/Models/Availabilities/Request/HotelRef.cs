using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;

/// <summary>
/// Hotel reference
/// </summary>
public record HotelRef
{
    /// <summary>
    /// Hotel identifier
    /// </summary>
    [XmlAttribute]
    public string HotelCode { get; init; } = string.Empty;
}

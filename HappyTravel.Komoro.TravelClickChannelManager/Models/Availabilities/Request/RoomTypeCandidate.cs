using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;

/// <summary>
/// Room type candidate
/// </summary>
public record RoomTypeCandidate
{
    /// <summary>
    /// Room type identifier
    /// </summary>
    [XmlAttribute]
    public string RoomTypeCode { get; init; } = string.Empty;
}

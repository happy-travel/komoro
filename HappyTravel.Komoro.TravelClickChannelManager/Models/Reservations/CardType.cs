using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations;

/// <summary>
/// Card type
/// </summary>
public record CardType
{
    /// <summary>
    /// Payment card type code (see the Payment Card Codes list)
    /// </summary>
    [XmlAttribute]
    public string Code { get; init; } = string.Empty;
}

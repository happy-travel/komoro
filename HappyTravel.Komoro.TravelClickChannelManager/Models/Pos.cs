using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models;

/// <summary>
/// Point of Sale. TravelClick will only send this information if specifically requested by OTA partner.
/// </summary>
[XmlRoot(ElementName = "POS")]
public class Pos
{
    /// <summary>
    /// Source
    /// </summary>
    public Source Source { get; set; } = new();
}

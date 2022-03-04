using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities;

/// <summary>
/// Inventory count data
/// </summary>
public record InvCount
{
    /// <summary>
    /// Number of available rooms
    /// </summary>
    [XmlAttribute]
    public int Count { get; init; }

    /// <summary>
    /// OpenTravel Inventory Count Type (INV). Only "2" is supported for this request. This indicates that the value of @Count refers to the number
    /// of available rooms
    /// </summary>
    [XmlAttribute]
    public string CountType { get; init; } = "2";
}

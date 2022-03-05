using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities;

/// <summary>
/// List of inventory updates for the given hotel
/// </summary>
[XmlType(TypeName = "Inventories")]
public record Inventories
{
    /// <summary>
    /// Hotel identifier
    /// </summary>
    [XmlAttribute]
    public string HotelCode { get; init; } = string.Empty;

    /// <summary>
    /// Inventory details
    /// </summary>
    [XmlElement(ElementName = "Inventory")]
    public List<Inventory> InventoryList { get; init; } = null!;
}

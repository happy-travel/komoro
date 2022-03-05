using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.HotelProducts.Response;

public record RoomType
{
    /// <summary>
    /// Room type identifier
    /// </summary>
    [XmlAttribute]
    public string RoomTypeCode { get; init; } = string.Empty;

    /// <summary>
    /// Room type name
    /// </summary>
    [XmlAttribute]
    public string RoomTypeName { get; init; } = string.Empty;

    /// <summary>
    /// Integer. Maximum number of adults permitted in this room type. Optional in the case where occupancy is not relevant
    /// </summary>
    [XmlAttribute]
    public int MaxAdultOccupancy { get; init; }

    /// <summary>
    /// Integer. Maximum number of children permitted in this room type. Optional in the case where occupancy is not relevant OR if occupancy 
    /// is not distinguished by age.
    /// </summary>
    [XmlAttribute]
    public int MaxChildOccupancy { get; init; }

    /// <summary>
    /// Integer. Maximum number of infants permitted in this room type. Optional in the case where occupancy is not relevant OR if occupancy 
    /// is not distinguished by age.
    /// </summary>
    [XmlAttribute]
    public int MaxInfantOccupancy { get; init; }
}

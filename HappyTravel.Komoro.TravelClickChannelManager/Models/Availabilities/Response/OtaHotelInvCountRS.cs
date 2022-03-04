using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Response;

/// <summary>
/// Response to Get Inventory request
/// </summary>
[XmlRoot(ElementName = "OTA_HotelInvCountRS", Namespace = "http://www.opentravel.org/OTA/2003/05")]
public record OtaHotelInvCountRS : BaseResponse
{
    /// <summary>
    /// List of inventory details
    /// </summary>
    public Inventories Inventories { get; init; } = null!;
}

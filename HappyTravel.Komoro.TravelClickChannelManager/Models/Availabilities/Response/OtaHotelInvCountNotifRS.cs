using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Response;

/// <summary>
/// Response to Update Inventory request
/// </summary>
[XmlRoot(ElementName = "OTA_HotelInvCountNotifRS", Namespace = "http://www.opentravel.org/OTA/2003/05")]
public record OtaHotelInvCountNotifRS : BaseResponse
{
}

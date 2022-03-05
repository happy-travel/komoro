using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Response;

/// <summary>
/// Response to Update Availability Restrictions request
/// </summary>
[XmlRoot(ElementName = "OTA_HotelAvailNotifRS", Namespace = "http://www.opentravel.org/OTA/2003/05")]
public record OtaHotelAvailNotifRS : BaseResponse
{
}

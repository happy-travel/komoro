using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Response;

/// <summary>
/// Response to Update Rates request
/// </summary>
[XmlRoot(ElementName = "OtaHotelRatePlanNotifRS", Namespace = "http://www.opentravel.org/OTA/2003/05")]
public record OtaHotelRatePlanNotifRS : BaseResponse
{
}

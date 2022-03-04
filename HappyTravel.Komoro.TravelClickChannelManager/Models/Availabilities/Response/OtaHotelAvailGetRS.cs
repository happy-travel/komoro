using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Response;

/// <summary>
/// Response for Get Availability Restrictions request
/// </summary>
[XmlRoot(ElementName = "OTA_HotelAvailGetRS", Namespace = "http://www.opentravel.org/OTA/2003/05")]
public record OtaHotelAvailGetRS : BaseResponse
{
    public AvailStatusMessages AvailStatusMessages { get; init; } = null!;
}

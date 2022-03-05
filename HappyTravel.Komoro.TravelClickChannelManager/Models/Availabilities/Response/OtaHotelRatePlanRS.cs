using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Response;

/// <summary>
/// Response to Get Rates request
/// </summary>
[XmlRoot(ElementName = "OTA_HotelRatePlanRS", Namespace = "http://www.opentravel.org/OTA/2003/05")]
public record OtaHotelRatePlanRS : BaseResponse
{
    public RatePlans RatePlans { get; init; } = null!;
}

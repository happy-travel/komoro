using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Reservations.Responses;

/// <summary>
/// Response to Creating and Modifying Reservations request
/// </summary>
[XmlRoot(ElementName = "OTA_HotelResNotifRS", Namespace = "http://www.opentravel.org/OTA/2003/05")]
public record OtaHotelResNotifRS : BaseResponse
{
    public List<HotelReservation> HotelReservations { get; init; } = null!;
}

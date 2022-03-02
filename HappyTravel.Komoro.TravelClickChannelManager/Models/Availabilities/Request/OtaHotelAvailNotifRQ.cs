using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;

/// <summary>
/// The request below sets all possible restriction types for a product, but this will not always be the case. OTA_HotelAvailNotifRQ messages may not
/// always contain every RestrictionStatus element for all restriction types. If a message is received that omits a particular restriction type, that
/// restriction's status should remain unchanged.
/// </summary>
[XmlRoot(ElementName = "OTA_HotelAvailNotifRQ", Namespace = "http://www.opentravel.org/OTA/2003/05")]
public class OtaHotelAvailNotifRQ : BaseRequest
{
    /// <summary>
    /// Point of Sale. TravelClick will only send this information if specifically requested by OTA partner.
    /// </summary>
    [XmlElement(ElementName = "POS")]
    public Pos? Pos { get; set; } = new();
}

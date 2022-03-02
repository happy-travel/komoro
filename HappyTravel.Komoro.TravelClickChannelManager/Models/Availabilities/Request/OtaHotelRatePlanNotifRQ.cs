using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;

/// <summary>
/// Update Rates
/// Request is initiated by TravelClick
/// Rate updates can include rate details based on the amount, number and age of the occupants.If the partner system does not support occupancy-based 
/// pricing, then is acceptable to interpret the BaseByGuestAmt with @NumberOfGuests of "2" and @AgeQualifyingCode of "10" as the room rate.TravelClick 
/// can send AmountBeforeTax(Rate not inclusive of taxes) OR AmountAfterTax(Rate inclusive of taxes) as per the partner's preference.
/// </summary>
[XmlRoot(ElementName = "OTA_HotelRatePlanNotifRQ", Namespace = "http://www.opentravel.org/OTA/2003/05")]
public record OtaHotelRatePlanNotifRQ : BaseRequest
{
    /// <summary>
    /// Point of Sale. TravelClick will only send this information if specifically requested by OTA partner.
    /// </summary>
    [XmlElement(ElementName = "POS")]
    public Pos? Pos { get; init; } = new();
}

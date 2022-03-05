using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;

/// <summary>
/// Get Rates
/// Request is initiated by TravelClick
/// The OTA_HotelRatePlanRQ is used to fetch the current rates for a given date range and rate plan(s). The RatePlan element contains a list of rate plan
/// codes under RatePlanCandidates.
/// </summary>
[XmlRoot(ElementName = "OTA_HotelRatePlanRQ", Namespace = "http://www.opentravel.org/OTA/2003/05")]
public record OtaHotelRatePlanRQ : BaseRequest
{
    /// <summary>
    /// Point of Sale. TravelClick will only send this information if specifically requested by OTA partner.
    /// </summary>
    [XmlElement(ElementName = "POS")]
    public Pos Pos { get; init; } = null!;

    /// <summary>
    /// List of hotel rate plans
    /// </summary>
    public List<RatePlanWithCandidates> RatePlans { get; init; } = null!;
}

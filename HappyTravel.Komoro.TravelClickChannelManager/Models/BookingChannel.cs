using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models;

public class BookingChannel
{
    /// <summary>
    /// "7" is the only currently supported value
    /// </summary>
    [XmlAttribute]
    public string Type { get; set; } = "7";

    /// <summary>
    /// OTA partner name. The OTA partner needs to provide what value they expect to be send by TravelClick.
    /// </summary>
    public CompanyName CompanyName { get; set; } = new();
}

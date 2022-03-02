using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;

/// <summary>
/// Length of stay restriction details
/// </summary>
public class LengthOfStay
{
    /// <summary>
    /// Currently the only supported value is "MinLOS" which indicates this is a minimum length of stay restriction
    /// </summary>
    [XmlAttribute]
    public string MinMaxMessageType { get; set; } = "MinLOS";

    /// <summary>
    /// Currently only "Day" is supported which indicates that the restriction is specified in number of days
    /// </summary>
    [XmlAttribute]
    public string TimeUnit { get; set; } = "Day";

    /// <summary>
    /// Length of stay restriction value. For instance, if this has a value of "3" and @TimeUnit is set to "Day" then the length of stay restriction
    /// is 3 days.
    /// </summary>
    [XmlAttribute]
    public int Time { get; set; }
}

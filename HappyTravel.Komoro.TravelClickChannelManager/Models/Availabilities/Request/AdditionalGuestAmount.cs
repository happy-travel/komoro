using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities.Request;

/// <summary>
/// Additional guest amount details
/// </summary>
public record AdditionalGuestAmount
{
    /// <summary>
    /// Rate increase amount for each additional guest
    /// </summary>
    [XmlAttribute]
    public decimal Amount { get; init; }

    /// <summary>
    /// Integer. Code indicating the age this additional amount applies to. "10" for Adults and "8" for Children. Optional if age is not relevant.
    /// </summary>
    [XmlAttribute]
    public int AgeQualifyingCode { get; init; }
}

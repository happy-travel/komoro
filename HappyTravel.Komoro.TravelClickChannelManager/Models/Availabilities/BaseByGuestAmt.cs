using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Availabilities;

/// <summary>
/// Rate details
/// </summary>
public record BaseByGuestAmt
{
    /// <summary>
    /// Rate for the given number of guests(Not inclusive of taxes). Either @AmountBeforeTax OR @AmountAfterTax depending on partner system.
    /// </summary>
    [XmlAttribute]
    public decimal AmountBeforeTax { get; init; }

    /// <summary>
    /// Rate for the given number of guests(Inclusive of taxes). Either @AmountBeforeTax OR @AmountAfterTax depending on partner system.
    /// </summary>
    [XmlAttribute]
    public decimal AmountAfterTax { get; init; }

    /// <summary>
    /// Integer. Number of guests to which this rate applies. Optional if occupancies are not relevant
    /// </summary>
    [XmlAttribute]
    public int NumberOfGuests { get; init; }

    /// <summary>
    /// Integer. Code indicating the age of the guests. Only "10" for Adults is supported.
    /// </summary>
    [XmlAttribute]
    public string? AgeQualifyingCode { get; init; }
}

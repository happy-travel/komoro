using HappyTravel.Komoro.TravelClickChannelManager.Models.Enums;
using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models;

/// <summary>
/// Error
/// </summary>
public record Error
{
    /// <summary>
    /// Integer. Error type (See OpenTravel Error Warning Type (EWT) code list)
    /// </summary>
    [XmlAttribute]
    public ErrorWarningTypes Type { get; init; }

    /// <summary>
    /// Integer. Error code (See OpenTravel ERR code list)
    /// </summary>
    [XmlAttribute]
    public ErrorCodes Code { get; init; }

    /// <summary>
    /// Short description of the error type
    /// </summary>
    [XmlAttribute]
    public string ShortText { get; init; } = string.Empty;

    /// <summary>
    /// Error details. The text node of this element contains the detailed description of the error
    /// </summary>
    [XmlText]
    public string ErrorText { get; init; } = string.Empty;
}

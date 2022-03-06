using HappyTravel.Komoro.TravelClickChannelManager.Models.Enums;
using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models;

/// <summary>
/// Warning
/// </summary>
public record Warning
{
    /// <summary>
    /// Integer. Error type (See OpenTravel Error Warning Type (EWT) code list)
    /// </summary>
    [XmlAttribute]
    public ErrorWarningTypes Type { get; init; }

    /// <summary>
    /// Integer. Error type code. (See OpenTravel Error Warning Type (EWT) code list).
    /// </summary>
    [XmlAttribute]
    public ErrorCodes Code { get; init; }

    /// <summary>
    /// Short description of the error type
    /// </summary>
    [XmlAttribute]
    public string ShortText { get; init; } = string.Empty;

    /// <summary>
    /// Warning details. The text node of this element contains the detailed description of the warning
    /// </summary>
    [XmlText]
    public string WarningText { get; init; } = string.Empty;
}

using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models;

public record BaseResponse
{
    [XmlAttribute]
    public string Version { get; init; } = string.Empty;

    [XmlAttribute]
    public DateTimeOffset TimeStamp { get; init; }

    [XmlAttribute]
    public string EchoToken { get; init; } = string.Empty;

    /// <summary>
    /// Empty element to indicate that the request was successful. Required to indicate success, but expected to be omitted when there are errors.
    /// </summary>
    public Success? Success { get; init; }

    /// <summary>
    /// Required to indicate that the request was NOT successful. Must contain one or more Error elements describing the cause
    /// </summary>
    public List<Error>? Errors { get; init; }

    /// <summary>
    /// Required to indicate that part of the request failed. Must contain one or more Warning elements describing the cause
    /// </summary>
    public List<Warning>? Warnings { get; init; }
}

using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Enums;

/// <summary>
/// Error Warning Types
/// </summary>
public enum ErrorWarningTypes
{
    /// <summary>
    /// Unknown
    /// </summary>
    [XmlEnum(Name = "1")]
    Unknown = 1,

    /// <summary>
    /// No Implementation
    /// </summary>
    [XmlEnum(Name = "2")]
    NoImplementation = 2,

    /// <summary>
    /// Business rule
    /// </summary>
    [XmlEnum(Name = "3")]
    BusinessRule = 3,

    /// <summary>
    /// Authentication
    /// </summary>
    [XmlEnum(Name = "4")]
    Authentication = 4,

    /// <summary>
    /// Required field missing
    /// </summary>
    [XmlEnum(Name = "10")]
    RequiredFieldMissing = 10,

    /// <summary>
    /// Application error
    /// </summary>
    [XmlEnum(Name = "13")]
    ApplicationError = 13
}

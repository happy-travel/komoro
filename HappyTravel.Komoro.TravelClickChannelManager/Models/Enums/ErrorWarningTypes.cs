namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Enums;

/// <summary>
/// Error Warning Types
/// </summary>
public enum ErrorWarningTypes
{
    /// <summary>
    /// Unknown
    /// </summary>
    Unknown = 1,

    /// <summary>
    /// No Implementation
    /// </summary>
    NoImplementation = 2,

    /// <summary>
    /// Business rule
    /// </summary>
    BusinessRule = 3,

    /// <summary>
    /// Authentication
    /// </summary>
    Authentication = 4,

    /// <summary>
    /// Required field missing
    /// </summary>
    RequiredFieldMissing = 10,

    /// <summary>
    /// Application error
    /// </summary>
    ApplicationError = 13
}

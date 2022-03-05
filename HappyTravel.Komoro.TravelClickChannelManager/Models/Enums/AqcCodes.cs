namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Enums;

/// <summary>
/// Age qualifier codes
/// </summary>
public enum AqcCodes
{
    /// <summary>
    /// Indicates that the associated value applies to infants
    /// </summary>
    Infant = 7,

    /// <summary>
    /// Indicates that the associated value applies to children
    /// </summary>
    Child = 8,

    /// <summary>
    /// Indicates that the associated value applies to adults. This code should be used when a system does not support age-based pricing
    /// </summary>
    Adult = 10
}

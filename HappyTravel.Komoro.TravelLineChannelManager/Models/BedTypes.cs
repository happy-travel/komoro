using System.Runtime.Serialization;

namespace HappyTravel.Komoro.TravelLineChannelManager.Models;

/// <summary>
/// Placement type
/// </summary>
internal enum BedTypes
{
    /// <summary>
    /// Accommodation of an adult in the main place
    /// </summary>
    [EnumMember(Value = "adultBed")]
    AdultBed = 0,

    /// <summary>
    /// Accommodation of an adult on extra bed place
    /// </summary>
    [EnumMember(Value = "adultExtraBed")]
    AdultExtraBed = 1,

    /// <summary>
    /// Placement of the child in the main place
    /// </summary>
    [EnumMember(Value = "childBandBed")]
    ChildBandBed = 2,

    /// <summary>
    /// Placement of a child in an extra bed
    /// </summary>
    [EnumMember(Value = "childBandExtraBed")]
    ChildBandExtraBed = 3,

    /// <summary>
    /// Placement an infant without a seat
    /// </summary>
    [EnumMember(Value = "childBandWithoutBed")]
    ChildBandWithoutBed = 4
}

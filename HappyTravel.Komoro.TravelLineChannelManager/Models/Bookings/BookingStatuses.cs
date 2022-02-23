using System.Runtime.Serialization;

namespace HappyTravel.Komoro.TravelLineChannelManager.Models.Bookings;

/// <summary>
/// Booking statuses
/// </summary>
internal enum BookingStatuses
{
    /// <summary>
    /// New booking
    /// </summary>
    [EnumMember(Value = "new")]
    New = 1,

    /// <summary>
    /// Modification of an existing booking
    /// </summary>
    [EnumMember(Value = "modified")]
    Modified = 2,

    /// <summary>
    /// Cancellation of an existing booking
    /// </summary>
    [EnumMember(Value = "cancelled")]
    Cancelled = 3
}

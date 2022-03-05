using System.Runtime.Serialization;

namespace HappyTravel.Komoro.TravelLineChannelManager.Models;

/// <summary>
/// The ID of the requested action from the set
/// </summary>
internal enum Actions
{
    /// <summary>
    /// Request to get rate plans and room categories from a channel
    /// </summary>
    [EnumMember(Value = "get-rooms-and-rate-plans")]
    GetRoomsAndRatePlans = 1,

    /// <summary>
    /// The request to get bookings from the channel
    /// </summary>
    [EnumMember(Value = "get-bookings")]
    GetBookings = 2,

    /// <summary>
    /// The request to confirm bookings from the channel
    /// </summary>
    [EnumMember(Value = "confirm-bookings")]
    ConfirmBookings = 3
}

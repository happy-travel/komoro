using System.Runtime.Serialization;

namespace HappyTravel.Komoro.TravelLineChannelManager.Models.Bookings;

/// <summary>
/// Payment method
/// </summary>
internal enum PaymentMethods
{
    /// <summary>
    /// Credit card
    /// </summary>
    [EnumMember(Value = "CREDIT")]
    Credit = 1,

    /// <summary>
    /// Cash on arrival
    /// </summary>
    [EnumMember(Value = "CASH")]
    Cash = 2,

    /// <summary>
    /// Prepaid reservation
    /// </summary>
    [EnumMember(Value = "PREPAY")]
    Prepay = 3
}

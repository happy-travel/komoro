using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Enums;

/// <summary>
/// Error Codes
/// </summary>
public enum ErrorCodes
{
    /// <summary>
    /// Error Warning Type = 4. Service restriction - security. Provided credentials are invalid
    /// </summary>
    [XmlEnum(Name = "195")]
    [EnumMember(Value = "Service restriction - security")]
    [Description("Provided credentials are invalid")]
    ServiceRestrictionSecurity = 195,

    /// <summary>
    /// Error Warning Type = 4. Invalid hotel. Provided HotelCode is invalid or not accessible
    /// </summary>
    [XmlEnum(Name = "361")]
    [EnumMember(Value = "Invalid hotel")]
    [Description("Provided HotelCode is invalid or not accessible")]
    InvalidHotel = 361,

    /// <summary>
    /// Error Warning Type = 3. Invalid date. The specified date is out of range or formatted incorrectly
    /// </summary>
    [XmlEnum(Name = "14")]
    [EnumMember(Value = "Invalid date")]
    [Description("The specified date is out of range or formatted incorrectly")]
    InvalidDate = 14,

    /// <summary>
    /// Error Warning Type = 3. Invalid rate code. Rate code does not exist or is not accessible
    /// </summary>
    [XmlEnum(Name = "249")]
    [EnumMember(Value = "Invalid rate code")]
    [Description("Rate code does not exist or is not accessible")]
    InvalidRateCode = 249,

    /// <summary>
    /// Error Warning Type = 3. Invalid room type. Room code does not exist or is not accessible
    /// </summary>
    [XmlEnum(Name = "402")]
    [EnumMember(Value = "Invalid room type")]
    [Description("Room code does not exist or is not accessible")]
    InvalidRoomType = 402
}

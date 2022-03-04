namespace HappyTravel.Komoro.TravelClickChannelManager.Models.Enums;

/// <summary>
/// Error Codes
/// </summary>
public enum ErrorCodes
{
    /// <summary>
    /// Error Warning Type = 4. Service restriction - security. Provided credentials are invalid
    /// </summary>
    ServiceRestrictionSecurity = 195,

    /// <summary>
    /// Error Warning Type = 4. Invalid hotel. Provided HotelCode is invalid or not accessible
    /// </summary>
    InvalidHotel = 361,

    /// <summary>
    /// Error Warning Type = 3. Invalid date. The specified date is out of range or formatted incorrectly
    /// </summary>
    InvalidDate = 14,

    /// <summary>
    /// Error Warning Type = 3. Invalid rate code. Rate code does not exist or is not accessible
    /// </summary>
    InvalidRateCode = 249,

    /// <summary>
    /// Error Warning Type = 3. Invalid room type. Room code does not exist or is not accessible
    /// </summary>
    InvalidRoomType = 402
}

namespace HappyTravel.Komoro.TravelLineChannelManager.Models;

/// <summary>
/// Base request for all request data models
/// </summary>
internal record BaseRequest
{
    /// <summary>
    /// Channel manager username in the channel
    /// </summary>
    public string Username { get; init; } = string.Empty;

    /// <summary>
    /// Channel manager user password in the channel
    /// </summary>
    public string Password { get; init; } = string.Empty;

    /// <summary>
    /// The ID of the requested action from the set. In this case: get-bookings
    /// </summary>
    public Actions Action { get; init; }
}

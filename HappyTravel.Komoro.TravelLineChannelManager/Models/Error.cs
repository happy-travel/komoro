namespace HappyTravel.Komoro.TravelLineChannelManager.Models;

/// <summary>
/// Error
/// </summary>
internal record Error
{
    /// <summary>
    /// Error code
    /// </summary>
    public int Code { get; init; }

    /// <summary>
    /// Error message
    /// </summary>
    public string Message { get; init; } = string.Empty;
}

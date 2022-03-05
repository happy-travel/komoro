namespace HappyTravel.Komoro.TravelLineChannelManager.Models;

/// <summary>
/// Warning
/// </summary>
internal record Warning
{
    /// <summary>
    /// Warning code
    /// </summary>
    public int Code { get; init; }

    /// <summary>
    /// Warning message
    /// </summary>
    public string Message { get; init; } = string.Empty;
}

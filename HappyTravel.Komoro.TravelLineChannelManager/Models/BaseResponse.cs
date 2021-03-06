namespace HappyTravel.Komoro.TravelLineChannelManager.Models;

/// <summary>
/// Base response for all response data models
/// </summary>
internal record BaseResponse
{
    /// <summary>
    /// Query execution result: true – if the query was executed without errors; false - if there were errors as a result of the execution.
    /// </summary>
    public bool Success { get; init; }

    /// <summary>
    /// Warnings
    /// </summary>
    public List<Warning> Warnings { get; init; } = new();

    /// <summary>
    /// Errors
    /// </summary>
    public List<Error> Errors { get; init; } = new();
}

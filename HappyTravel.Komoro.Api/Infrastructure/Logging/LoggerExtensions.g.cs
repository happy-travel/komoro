using System;
using Microsoft.Extensions.Logging;

namespace HappyTravel.Komoro.Api.Infrastructure.Logging;

public static partial class LoggerExtensions
{
    [LoggerMessage(3011, LogLevel.Information, "Booking request started")]
    static partial void BookingRequestStarted(ILogger logger);
    
    [LoggerMessage(3012, LogLevel.Information, "Booking request completed")]
    static partial void BookingRequestCompleted(ILogger logger);
    
    [LoggerMessage(3013, LogLevel.Warning, "Booking request failed with error `{Error}`")]
    static partial void BookingRequestFailed(ILogger logger, string Error);
    
    [LoggerMessage(3014, LogLevel.Information, "Cancel booking request started")]
    static partial void CancelBookingRequestStarted(ILogger logger);
    
    [LoggerMessage(3015, LogLevel.Information, "Cancel booking request completed")]
    static partial void CancelBookingRequestCompleted(ILogger logger);
    
    [LoggerMessage(3016, LogLevel.Warning, "Cancel booking request failed with error `{Error}`")]
    static partial void CancelBookingRequestFailed(ILogger logger, string Error);
    
    [LoggerMessage(3017, LogLevel.Information, "Booking status request started")]
    static partial void BookingStatusRequestStarted(ILogger logger);
    
    [LoggerMessage(3018, LogLevel.Information, "Booking status request completed")]
    static partial void BookingStatusRequestCompleted(ILogger logger);
    
    [LoggerMessage(3019, LogLevel.Warning, "Booking status request failed with error `{Error}`")]
    static partial void BookingStatusRequestFailed(ILogger logger, string Error);
    
    [LoggerMessage(3020, LogLevel.Information, "Search request started")]
    static partial void SearchRequestStarted(ILogger logger);
    
    [LoggerMessage(3021, LogLevel.Information, "Search request completed")]
    static partial void SearchRequestCompleted(ILogger logger);
    
    [LoggerMessage(3022, LogLevel.Warning, "Search request failed with error `{Error}`")]
    static partial void SearchRequestFailed(ILogger logger, string Error);
    
    [LoggerMessage(3023, LogLevel.Information, "Accommodation request started")]
    static partial void AccommodationRequestStarted(ILogger logger);
    
    [LoggerMessage(3024, LogLevel.Information, "Accommodation request completed")]
    static partial void AccommodationRequestCompleted(ILogger logger);
    
    [LoggerMessage(3025, LogLevel.Warning, "Accommodation request failed with error `{Error}`")]
    static partial void AccommodationRequestFailed(ILogger logger, string Error);
    
    [LoggerMessage(3026, LogLevel.Information, "Room request started")]
    static partial void RoomRequestStarted(ILogger logger);
    
    [LoggerMessage(3027, LogLevel.Information, "Room request completed")]
    static partial void RoomRequestCompleted(ILogger logger);
    
    [LoggerMessage(3028, LogLevel.Warning, "Room request failed with error `{Error}`")]
    static partial void RoomRequestFailed(ILogger logger, string Error);
    
    [LoggerMessage(3032, LogLevel.Information, "Deadline request started")]
    static partial void DeadlineRequestStarted(ILogger logger);
    
    [LoggerMessage(3033, LogLevel.Information, "Deadline request completed")]
    static partial void DeadlineRequestCompleted(ILogger logger);
    
    [LoggerMessage(3034, LogLevel.Warning, "Deadline request failed with error `{Error}`")]
    static partial void DeadlineRequestFailed(ILogger logger, string Error);
    
    
    
    public static void LogBookingRequestStarted(this ILogger logger)
        => BookingRequestStarted(logger);
    
    public static void LogBookingRequestCompleted(this ILogger logger)
        => BookingRequestCompleted(logger);
    
    public static void LogBookingRequestFailed(this ILogger logger, string Error)
        => BookingRequestFailed(logger, Error);
    
    public static void LogCancelBookingRequestStarted(this ILogger logger)
        => CancelBookingRequestStarted(logger);
    
    public static void LogCancelBookingRequestCompleted(this ILogger logger)
        => CancelBookingRequestCompleted(logger);
    
    public static void LogCancelBookingRequestFailed(this ILogger logger, string Error)
        => CancelBookingRequestFailed(logger, Error);
    
    public static void LogBookingStatusRequestStarted(this ILogger logger)
        => BookingStatusRequestStarted(logger);
    
    public static void LogBookingStatusRequestCompleted(this ILogger logger)
        => BookingStatusRequestCompleted(logger);
    
    public static void LogBookingStatusRequestFailed(this ILogger logger, string Error)
        => BookingStatusRequestFailed(logger, Error);
    
    public static void LogSearchRequestStarted(this ILogger logger)
        => SearchRequestStarted(logger);
    
    public static void LogSearchRequestCompleted(this ILogger logger)
        => SearchRequestCompleted(logger);
    
    public static void LogSearchRequestFailed(this ILogger logger, string Error)
        => SearchRequestFailed(logger, Error);
    
    public static void LogAccommodationRequestStarted(this ILogger logger)
        => AccommodationRequestStarted(logger);
    
    public static void LogAccommodationRequestCompleted(this ILogger logger)
        => AccommodationRequestCompleted(logger);
    
    public static void LogAccommodationRequestFailed(this ILogger logger, string Error)
        => AccommodationRequestFailed(logger, Error);
    
    public static void LogRoomRequestStarted(this ILogger logger)
        => RoomRequestStarted(logger);
    
    public static void LogRoomRequestCompleted(this ILogger logger)
        => RoomRequestCompleted(logger);
    
    public static void LogRoomRequestFailed(this ILogger logger, string Error)
        => RoomRequestFailed(logger, Error);
    
    public static void LogDeadlineRequestStarted(this ILogger logger)
        => DeadlineRequestStarted(logger);
    
    public static void LogDeadlineRequestCompleted(this ILogger logger)
        => DeadlineRequestCompleted(logger);
    
    public static void LogDeadlineRequestFailed(this ILogger logger, string Error)
        => DeadlineRequestFailed(logger, Error);
}
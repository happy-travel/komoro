using HappyTravel.StdOutLogger.Extensions;
using HappyTravel.StdOutLogger.Infrastructure;
using HappyTravel.Komoro.Api.Infrastructure.Environment;

namespace HappyTravel.Komoro.Api.Infrastructure.ConfigurationExtensions;

public static class LoggingExtensions
{
    public static void ConfigureLogging(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();
        
        if (builder.Environment.IsLocal())
            builder.Logging.AddConsole();
        else
        {
            builder.Logging.AddStdOutLogger(setup =>
            {
                setup.IncludeScopes = true;
                setup.RequestIdHeader = Constants.DefaultRequestIdHeader;
                setup.UseUtcTimestamp = true;
            });
            builder.Logging.AddSentry();
        }
    }
}
using FloxDc.CacheFlow;

namespace HappyTravel.Komoro.Api.Infrastructure.ConfigurationExtensions;

public static class FlowOptionsExtensions
{
    public static void ConfigureFlowOptions(this IServiceCollection services)
    {
        services.Configure<FlowOptions>(options =>
        {
            options.DataLoggingLevel = DataLogLevel.Normal;
            options.SuppressCacheExceptions = false;
            options.CacheKeyDelimiter = "::";
            options.CacheKeyPrefix = "HappyTravel::Komoro";
        });
    }
}
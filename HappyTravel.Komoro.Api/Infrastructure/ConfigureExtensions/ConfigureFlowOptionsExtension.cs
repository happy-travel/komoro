using FloxDc.CacheFlow;

namespace HappyTravel.Komoro.Api.Infrastructure.ConfigureExtensions;

public static class ConfigureFlowOptionsExtension
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
using HappyTravel.Komoro.Api.Infrastructure.Environment;
using HappyTravel.Telemetry.Extensions;

namespace HappyTravel.Komoro.Api.Infrastructure.ConfigurationExtensions;

public static class TracingExtensions
{
    public static void ConfigureTracing(this IServiceCollection services, IWebHostEnvironment environment, IConfiguration configuration)
    {
        services.AddTracing(configuration, options =>
        {
            options.ServiceName = $"{environment.ApplicationName}-{environment.EnvironmentName}";
            options.JaegerHost = environment.IsLocal()
                ? configuration.GetValue<string>("Jaeger:AgentHost")
                : configuration.GetValue<string>(configuration.GetValue<string>("Jaeger:AgentHost"));
            options.JaegerPort = environment.IsLocal()
                ? configuration.GetValue<int>("Jaeger:AgentPort")
                : configuration.GetValue<int>(configuration.GetValue<string>("Jaeger:AgentPort"));
        });
    }
}
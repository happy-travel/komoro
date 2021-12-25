using HappyTravel.ConsulKeyValueClient.ConfigurationProvider.Extensions;
using HappyTravel.Komoro.Api.Infrastructure.Environment;

namespace HappyTravel.Komoro.Api.Infrastructure.ConfigureExtensions;

public static class ConfigureAppConfigurationExtension
{
    public static void ConfigureAppConfiguration(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(System.Environment.GetEnvironmentVariable("CONSUL_HTTP_ADDR"));
        ArgumentNullException.ThrowIfNull(System.Environment.GetEnvironmentVariable("CONSUL_HTTP_TOKEN"));
        
        var environment = builder.Environment;

        builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        builder.Configuration.AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
        builder.Configuration.AddEnvironmentVariables();
        builder.Configuration.AddConsulKeyValueClient(url: System.Environment.GetEnvironmentVariable("CONSUL_HTTP_ADDR")!,
            key: "sunpu",
            token: System.Environment.GetEnvironmentVariable("CONSUL_HTTP_TOKEN")!,
            bucketName: environment.EnvironmentName,
            optional: environment.IsLocal());
    }
}
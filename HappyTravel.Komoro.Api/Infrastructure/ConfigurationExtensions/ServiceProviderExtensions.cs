namespace HappyTravel.Komoro.Api.Infrastructure.ConfigurationExtensions;

public static class ServiceProviderExtensions
{
    public static void ConfigureServiceProvider(this WebApplicationBuilder builder)
    {
        builder.WebHost.UseDefaultServiceProvider(o =>
        {
            o.ValidateScopes = true;
            o.ValidateOnBuild = true;
        });
    }
}
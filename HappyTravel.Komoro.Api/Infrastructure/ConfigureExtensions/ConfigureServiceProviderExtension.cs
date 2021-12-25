namespace HappyTravel.Komoro.Api.Infrastructure.ConfigureExtensions;

public static class ConfigureServiceProviderExtension
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
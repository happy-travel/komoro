using Microsoft.AspNetCore.Mvc;

namespace HappyTravel.Komoro.Api.Infrastructure.ConfigurationExtensions;

public static class ApiVersioningExtensions
{
    public static void ConfigureApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = false;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
        });
    }
}
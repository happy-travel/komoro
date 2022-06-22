using System.Reflection;
using Microsoft.OpenApi.Models;

namespace HappyTravel.Komoro.Api.Infrastructure.ConfigurationExtensions;

public static class SwaggerConfigurationExtensions
{
    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.UseDateOnlyTimeOnlyStringConverters();
            options.SwaggerDoc("komoro", new OpenApiInfo {Title = "HappyTravel.com Komoro API for admin app", Version = "v1.0"});
            options.SwaggerDoc("travel-click", new OpenApiInfo { Title = "HappyTravel.com Komoro API for TravelClick channel", Version = "v1.0" });
            options.SwaggerDoc("travel-line", new OpenApiInfo { Title = "HappyTravel.com Komoro API for TravelLine channel", Version = "v1.0" });

            var xmlCommentsFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlCommentsFilePath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFileName);
            options.IncludeXmlComments(xmlCommentsFilePath);
            options.CustomSchemaIds(type => type.ToString());
        });
    }
}
using System.Reflection;
using Microsoft.OpenApi.Models;

namespace HappyTravel.Komoro.Api.Infrastructure.ConfigurationExtensions;

public static class SwaggerConfigurationExtensions
{
    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1.0", new OpenApiInfo {Title = "HappyTravel.com Komoro API", Version = "v1.0"});

            var xmlCommentsFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlCommentsFilePath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFileName);
            options.IncludeXmlComments(xmlCommentsFilePath);
            options.CustomSchemaIds(type => type.ToString());
        });
    }
}
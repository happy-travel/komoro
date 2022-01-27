using FloxDc.CacheFlow.Extensions;
using HappyTravel.ErrorHandling.Extensions;
using HappyTravel.Komoro.Api.Services;
using HappyTravel.Komoro.Api.Services.Converters;

namespace HappyTravel.Komoro.Api.Infrastructure.ConfigureExtensions;

public static class ConfigureServicesExtension
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers(options => options.UseDateOnlyTimeOnlyStringConverters())
            .AddJsonOptions(options => options.UseDateOnlyTimeOnlyStringConverters());
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(o => o.UseDateOnlyTimeOnlyStringConverters());
        builder.Services.AddHealthChecks();
        builder.Services.AddProblemDetailsErrorHandling();
        builder.Services.AddResponseCompression();
        builder.Services.AddMemoryCache();
        builder.Services.AddMemoryFlow();
        builder.Services.ConfigureApiVersioning();
        builder.Services.ConfigureTracing(builder.Environment, builder.Configuration);
        builder.Services.ConfigureFlowOptions();
        builder.Services.ConfigureSwagger();

        builder.Services.AddTransient<ICancellationPolicyService, CancellationPolicyService>();
        builder.Services.AddTransient<IMealPlanService, MealPlanService>();
        builder.Services.AddTransient<IPropertyService, PropertyService>();
        builder.Services.AddTransient<TravelClickConverter>();
        builder.Services.AddTransient<IRoomService, RoomService>();
        builder.Services.AddTransient<IRoomTypeService, RoomTypeService>();

        builder.Services.AddTransient<TravelClickConverter>();

        builder.Services.AddTransient<IAccommodationStorage, AccommodationStorage>();
    }
}
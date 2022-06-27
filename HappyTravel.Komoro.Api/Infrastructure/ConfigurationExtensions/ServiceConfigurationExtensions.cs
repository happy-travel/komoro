using FloxDc.CacheFlow.Extensions;
using HappyTravel.ErrorHandling.Extensions;
using HappyTravel.Komoro.Api.Infrastructure.Conventions;
using HappyTravel.Komoro.Api.Services.Availabilities;
using HappyTravel.Komoro.Api.Services.Converters;
using HappyTravel.Komoro.Api.Services.Statics;
using HappyTravel.Komoro.Common.Services.Availabilities;
using HappyTravel.Komoro.Common.Services.Statics;
using HappyTravel.Komoro.TravelClickChannelManager.Infrastructure.Extensions;
using System.Text.Json.Serialization;

namespace HappyTravel.Komoro.Api.Infrastructure.ConfigurationExtensions;

public static class ServiceConfigurationExtensions
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddMvcCore(options =>
        {
            options.Conventions.Add(new ApiExplorerGroupConvention());
        });

        builder.Services.AddControllers(options => options.UseDateOnlyTimeOnlyStringConverters())
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.UseDateOnlyTimeOnlyStringConverters();
            })
            .AddXmlSerializerFormatters();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddCors();
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
        builder.Services.AddTransient<ICountryService, CountryService>();
        builder.Services.AddTransient<IMealPlanService, MealPlanService>();
        builder.Services.AddTransient<IPropertyService, PropertyService>();
        builder.Services.AddTransient<IRoomService, RoomService>();
        builder.Services.AddTransient<IRoomTypeService, RoomTypeService>();
        builder.Services.AddTransient<IRatePlanService, RatePlanService>();
        builder.Services.AddTransient<IRoomCategoryService, RoomCategoryService>();
        builder.Services.AddTransient<INoShowPolicyService, NoShowPolicyService>();

        builder.Services.AddTransient<TravelClickPropertyConverter>();

        builder.Services.AddTransient<IAccommodationStorage, AccommodationStorage>();

        builder.Services.AddTransient<IInventoryService, InventoryService>();
        builder.Services.AddTransient<IAvailabilityRestrictionService, AvailabilityRestrictionService>();
        builder.Services.AddTransient<IRateService, RateService>();

        builder.Services.AddTravelClickClientServices();
    }
}
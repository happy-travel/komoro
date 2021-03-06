using HappyTravel.HttpRequestLogger;
using HappyTravel.Komoro.TravelLineChannelManager.Infrastructure.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using Prometheus;

namespace HappyTravel.Komoro.TravelLineChannelManager.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddTravelClickClient(this IServiceCollection serviceCollection, TravelLineClientOptions clientOptions, 
        IConfiguration configuration)
    {
        serviceCollection.Configure<TravelLineClientOptions>(options =>
        {
            options.Url = clientOptions.Url;
        });

        serviceCollection.AddHttpClient<ITravelLineClient, TravelLineClient>(client =>
            {
                client.BaseAddress = new Uri(clientOptions.Url);
                client.Timeout = TimeSpan.FromSeconds(120);
            })
            .UseHttpClientMetrics()
            .SetHandlerLifetime(TimeSpan.FromMinutes(5))
            .AddPolicyHandler(GetDefaultRetryPolicy())
            .AddHttpClientRequestLogging(configuration: configuration,
                sensitiveDataLoggingOptions: options =>
                {
                    options.SanitizingFunction = entry =>
                    {
                        var requestHeaders = entry.RequestHeaders;
                        if (requestHeaders is not null)
                            requestHeaders["Authorization"] = "[hidden]";

                        return entry with { RequestHeaders = requestHeaders };
                    };
                });
    }


    public static IServiceCollection AddTravelLineClientServices(this IServiceCollection services)
    {
        return services;
    }


    private static IAsyncPolicy<HttpResponseMessage> GetDefaultRetryPolicy()
    {
        var jitter = new Random();

        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(3, attempt
                => TimeSpan.FromSeconds(Math.Pow(1.5, attempt)) + TimeSpan.FromMilliseconds(jitter.Next(0, 100)));
    }
}

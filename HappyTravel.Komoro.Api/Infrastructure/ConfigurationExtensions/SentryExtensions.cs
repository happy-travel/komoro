using System.Diagnostics;

namespace HappyTravel.Komoro.Api.Infrastructure.ConfigurationExtensions;

public static class SentryExtensions
{
    public static void ConfigureSentry(this WebApplicationBuilder builder)
    {
        builder.WebHost.UseSentry(options =>
        {
            options.Dsn = System.Environment.GetEnvironmentVariable("HTDC_KOMORO_SENTRY_ENDPOINT");
            options.Environment = System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            options.IncludeActivityData = true;
            options.BeforeSend = sentryEvent =>
            {
                if (Activity.Current is null)
                    return sentryEvent;
                                
                foreach (var (key, value) in Activity.Current.Baggage)
                    sentryEvent.SetTag(key, value ?? string.Empty);

                sentryEvent.SetTag("TraceId", Activity.Current.TraceId.ToString());
                sentryEvent.SetTag("SpanId", Activity.Current.SpanId.ToString());

                return sentryEvent;
            };
        });
    }
}
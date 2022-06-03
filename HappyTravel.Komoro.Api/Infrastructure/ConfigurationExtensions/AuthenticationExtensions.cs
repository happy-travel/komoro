using HappyTravel.Komoro.Api.Infrastructure.Options;
using IdentityServer4.AccessTokenValidation;

namespace HappyTravel.Komoro.Api.Infrastructure.ConfigurationExtensions;

public static class AuthenticationExtensions
{
    public static void ConfigureAuthentication(this WebApplicationBuilder builder, AuthorityOptions authorityOptions)
    {
        builder.Services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = authorityOptions.AuthorityUrl;
                options.Audience = authorityOptions.Audience;
                options.RequireHttpsMetadata = true;
                options.AutomaticRefreshInterval = authorityOptions.AutomaticRefreshInterval;
            });
    }
}

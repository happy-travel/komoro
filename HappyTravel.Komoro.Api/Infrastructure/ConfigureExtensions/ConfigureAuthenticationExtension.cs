using IdentityServer4.AccessTokenValidation;

namespace HappyTravel.Komoro.Api.Infrastructure.ConfigureExtensions;

public static class ConfigureAuthenticationExtension
{
    public static void ConfigureAuthentication(this WebApplicationBuilder builder, Dictionary<string, string> authorityOptions)
    {
        builder.Services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            .AddIdentityServerAuthentication(options =>
            {
                options.Authority = authorityOptions["authorityUrl"];
                options.ApiName = authorityOptions["apiName"];
                options.RequireHttpsMetadata = true;
                options.SupportedTokens = SupportedTokens.Jwt;
            });
    }
}

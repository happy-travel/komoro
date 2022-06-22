using HappyTravel.ErrorHandling.Extensions;
using HappyTravel.Komoro.Api.Infrastructure.ConfigurationExtensions;
using HappyTravel.Komoro.Api.Infrastructure.Environment;
using HappyTravel.Komoro.Api.Infrastructure.Options;
using HappyTravel.Komoro.Common.Infrastructure.Options;
using HappyTravel.VaultClient;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var environment = builder.Environment;

using var vaultClient = new VaultClient(new VaultOptions
{
    BaseUrl = new Uri(EnvironmentVariableHelper.Get("Vault:Endpoint", configuration)),
    Engine = configuration["Vault:Engine"],
    Role = configuration["Vault:Role"]
});
vaultClient.Login(EnvironmentVariableHelper.Get("Vault:Token", configuration)).GetAwaiter().GetResult();

var databaseOptions = vaultClient.Get(configuration["Database:Options"]).GetAwaiter().GetResult();

builder.ConfigureAppConfiguration();
builder.ConfigureLogging();
builder.ConfigureSentry();
builder.ConfigureServiceProvider();
builder.ConfigureServices();
builder.ConfigureDatabaseOptions(databaseOptions);

var travelClickOptions = vaultClient.Get(configuration["TravelClick"]).GetAwaiter().GetResult();
builder.Services.Configure<TravelClickOptions>(options => 
{
    options.Login = travelClickOptions["login"];
    options.Password = travelClickOptions["password"];
});

var authorityOptions = configuration.GetSection("Authority").Get<AuthorityOptions>();
builder.ConfigureAuthentication(authorityOptions);

var app = builder.Build();

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/komoro/swagger.json", "HappyTravel.com Komoro API for admin app");
        options.SwaggerEndpoint("/swagger/travel-click/swagger.json", "HappyTravel.com Komoro API for TravelClick channel");
        options.SwaggerEndpoint("/swagger/travel-line/swagger.json", "HappyTravel.com Komoro API for TravelLine channel");
        options.RoutePrefix = string.Empty;
    });
}

app.UseCors(builder => builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
app.UseProblemDetailsErrorHandler(app.Environment, app.Logger);
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(b =>
{
    b.MapControllers();
    b.MapHealthChecks("/health");
});

app.Run();

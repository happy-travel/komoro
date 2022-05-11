using HappyTravel.ErrorHandling.Extensions;
using HappyTravel.Komoro.Api.Infrastructure.ConfigurationExtensions;
using HappyTravel.Komoro.Api.Infrastructure.Environment;
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
var authorityOptions = vaultClient.Get(configuration["Authority:Options"]).GetAwaiter().GetResult();

builder.ConfigureAppConfiguration();
builder.ConfigureLogging();
builder.ConfigureSentry();
builder.ConfigureServiceProvider();
builder.ConfigureServices();
builder.ConfigureDatabaseOptions(databaseOptions);
builder.ConfigureAuthentication(authorityOptions);

var app = builder.Build();

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(o =>
    {
        o.SwaggerEndpoint("/swagger/v1.0/swagger.json", "HappyTravel.com Komoro API");
        o.RoutePrefix = string.Empty;
    });
}

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
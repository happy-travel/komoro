using HappyTravel.ErrorHandling.Extensions;
using HappyTravel.Komoro.Api.Infrastructure.ConfigureExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureAppConfiguration();
builder.ConfigureLogging();
builder.ConfigureSentry();
builder.ConfigureServiceProvider();
builder.ConfigureServices();
builder.ConfigureDatabaseOptions();

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
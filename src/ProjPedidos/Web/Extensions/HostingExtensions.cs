using ProjPedidos.Application;
using ProjPedidos.Application.Common;
using ProjPedidos.Infrastructure;
using ProjPedidos.Infrastructure.Data;
using ProjPedidos.Web.Middlewares;

namespace ProjPedidos.Web.Extensions;

public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder, AppSettings appsettings)
    {
        builder.Services.AddInfrastructuresService(appsettings);
        builder.Services.AddApplicationService();
        builder.Services.AddWebAPIService(appsettings);

        return builder.Build();
    }

    public static async Task<WebApplication> ConfigurePipelineAsync(this WebApplication app, AppSettings appsettings)
    {
        using var loggerFactory = LoggerFactory.Create(builder => { });
        using var scope = app.Services.CreateScope();
        if (!appsettings.UseInMemoryDatabase)
        {
            var initialize = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
            await initialize.InitializeAsync();
        }
        else
        {
            var initialize = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            initialize.Database.EnsureCreated();
        }

        app.UseSwagger();
        app.UseSwaggerUI(setupAction =>
        {
            setupAction.SwaggerEndpoint("/swagger/OpenAPISpecification/swagger.json", "Pedidos");
            setupAction.RoutePrefix = "swagger";
        });

        app.UseCors("AllowSpecificOrigin");

        app.UseMiddleware<GlobalExceptionMiddleware>();

        app.UseMiddleware<PerformanceMiddleware>();

        app.UseResponseCompression();

        app.UseResponseCompression();

        app.UseHttpsRedirection();

        app.ConfigureHealthCheck();

        app.UseMiddleware<LoggingMiddleware>();

        app.ConfigureExceptionHandler(loggerFactory.CreateLogger("Exceptions"));

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}

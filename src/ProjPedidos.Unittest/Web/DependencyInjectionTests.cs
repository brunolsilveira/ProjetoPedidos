using System.Diagnostics;
using ProjPedidos.Application;
using ProjPedidos.Application.Common;
using ProjPedidos.Application.Common.Interfaces;
using ProjPedidos.Application.Services;
using ProjPedidos.Infrastructure;
using ProjPedidos.Web;
using ProjPedidos.Web.Middlewares;
using Microsoft.Extensions.DependencyInjection;

namespace ProjPedidos.Unittest.Web;

public class DependencyInjectionTests
{
    private readonly ServiceProvider _serviceProvider;
    private readonly AppSettings _appSettings = new()
    {
        ApplicationDetail = new ApplicationDetail
        {
            ApplicationName = "app",
            ContactWebsite = "http://dummy.html",
            Description = "description"
        },
        ConnectionStrings = new ConnectionStrings
        {
            DefaultConnection = "dummy"
        },
        UseInMemoryDatabase = false
    };

    public DependencyInjectionTests()
    {
        var service = new ServiceCollection();
        service.AddApplicationService();
        service.AddInfrastructuresService(_appSettings);
        service.AddWebAPIService(_appSettings);

        _serviceProvider = service.BuildServiceProvider();
    }

    [Fact]
    public void DependencyInjectionTests_ServiceShouldResolveCorrectly()
    {
        var currentTimeServiceResolved = _serviceProvider.GetRequiredService<ICurrentTime>();
        var exceptionMiddlewareResolved = _serviceProvider.GetRequiredService<GlobalExceptionMiddleware>();
        var performanceMiddleware = _serviceProvider.GetRequiredService<PerformanceMiddleware>();
        var stopwatchResolved = _serviceProvider.GetRequiredService<Stopwatch>();

        Assert.Equal(typeof(CurrentTime), currentTimeServiceResolved.GetType());
        Assert.Equal(typeof(GlobalExceptionMiddleware), exceptionMiddlewareResolved.GetType());
        Assert.Equal(typeof(Stopwatch), stopwatchResolved.GetType());
        Assert.Equal(typeof(PerformanceMiddleware), performanceMiddleware.GetType());
    }
}

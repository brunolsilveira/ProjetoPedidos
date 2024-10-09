using ProjPedidos.Application.Common.Interfaces;
using ProjPedidos.Application.Common.Utilities;
using ProjPedidos.Application.Services;
using ProjPedidos.Web.Services;

namespace ProjPedidos.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IPedidoService, PedidoService>();
        services.AddScoped<IMailService, MailService>();

        services.AddSingleton<ICurrentTime, CurrentTime>();
        services.AddSingleton<ICurrentUser, CurrentUser>();
        services.AddSingleton<ITokenService, TokenService>();
        services.AddSingleton<ICookieService, CookieService>();

        return services;
    }
}

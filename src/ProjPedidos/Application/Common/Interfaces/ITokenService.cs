using System.Security.Claims;

namespace ProjPedidos.Application.Common.Interfaces;

public interface ITokenService
{
    public string GenerateToken(User user);
    public ClaimsPrincipal ValidateToken(string token);
}

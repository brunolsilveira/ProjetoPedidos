using ProjPedidos.Application.Common.Models;

namespace ProjPedidos.Domain.Entities;

public class User : BaseModel
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Role Role { get; set; } = Role.User;
}

using ProjPedidos.Infrastructure.Data;
using ProjPedidos.Infrastructure.Interface;

namespace ProjPedidos.Application.Repositories;

public class UserRepository(ApplicationDbContext context) : GenericRepository<User>(context), IUserRepository
{
}

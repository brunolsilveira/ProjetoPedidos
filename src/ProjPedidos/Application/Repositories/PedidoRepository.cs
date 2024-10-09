using ProjPedidos.Infrastructure.Data;
using ProjPedidos.Infrastructure.Interface;

namespace ProjPedidos.Application.Repositories;

public class PedidoRepository(ApplicationDbContext context) : GenericRepository<Pedido>(context), IPedidoRepository
{
}

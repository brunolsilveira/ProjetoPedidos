using ProjPedidos.Application.Common.Models;
using ProjPedidos.Application.Common.Models.Pedido;

namespace ProjPedidos.Application.Common.Interfaces;

public interface IPedidoService
{
    Task<Pagination<PedidoResultDTO>> Get(int pageIndex, int pageSize, int? year);
    Task<PedidoResultDTO> Get(int id);
    Task Add(PedidoDTO request, CancellationToken token);
    Task Update(Pedido request, CancellationToken token);
    Task Delete(int id, CancellationToken token);
}

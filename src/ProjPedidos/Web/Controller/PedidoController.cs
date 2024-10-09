using ProjPedidos.Application.Common.Interfaces;
using ProjPedidos.Application.Common.Models.Pedido;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjPedidos.Web.Controller;


public class PedidoController(IPedidoService pedidoService) : BaseController
{
    private readonly IPedidoService _pedidoService = pedidoService;

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
        => Ok(await _pedidoService.Get(id));

    [HttpGet]
    public async Task<IActionResult> Get(int? year, int pageIndex = 0, int pageSize = 10)
        => Ok(await _pedidoService.Get(pageIndex, pageSize, year));

    [HttpPost]
    public async Task<IActionResult> Add(PedidoDTO request, CancellationToken token)
    {
        await _pedidoService.Add(request, token);
        return NoContent();
    }

    //[Authorize]
    [HttpPut]
    public async Task<IActionResult> Update(Pedido request, CancellationToken token)
    {
        await _pedidoService.Update(request, token);
        return NoContent();
    }

    //[Authorize]
    [HttpDelete]
    public async Task<IActionResult> Delete(int id, CancellationToken token)
    {
        await _pedidoService.Delete(id, token);
        return NoContent();
    }
}

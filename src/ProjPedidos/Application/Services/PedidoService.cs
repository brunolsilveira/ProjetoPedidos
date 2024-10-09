using AutoMapper;
using ProjPedidos.Application.Common.Interfaces;
using ProjPedidos.Application.Common.Models;
using ProjPedidos.Application.Common.Models.Pedido;

namespace ProjPedidos.Application.Services;

public class PedidoService(IUnitOfWork unitOfWork, IMapper mapper) : IPedidoService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<Pagination<PedidoResultDTO>> Get(int pageIndex, int pageSize, int? year)
    {
        var result = await _unitOfWork.PedidoRepository.GetAsync(x => x.DataCriacao.Year == (year ?? DateTime.Now.Year),
            x => new PedidoResultDTO
            {
                Id = x.Id,
                NomeCliente = x.NomeCliente,
                EmailCliente = x.EmailCliente,
                Pago = x.Pago,
                ValorTotal = x.ItensPedido.Sum(i => i.Quantidade * i.Produto.Valor),
                ItensPedido = x.ItensPedido.Select(i => new ItensPedidoResultDTO
                {
                    Id = i.Id,
                    IdProduto = i.IdProduto,
                    NomeProduto = i.Produto.NomeProduto,
                    ValorUnitario = i.Produto.Valor,
                    Quantidade = i.Quantidade
                })
            },
            pageIndex: pageIndex,
            pageSize: pageSize,
            orderBy: x => x.DataCriacao,
            ascending: false
            );

        return result;
    }

    public async Task<PedidoResultDTO> Get(int id)
    {
        string[] includes = { "ItensPedido", "ItensPedido.Produto" };

        var pedido = await _unitOfWork.PedidoRepository.FirstOrDefaultAsync(x => x.Id == id, includes);

        var result = new PedidoResultDTO
        {
            Id = pedido.Id,
            NomeCliente = pedido.NomeCliente,
            EmailCliente = pedido.EmailCliente,
            Pago = pedido.Pago,
            ValorTotal = pedido.ItensPedido.Sum(i => i.Quantidade * i.Produto.Valor),
            ItensPedido = pedido.ItensPedido.Select(i => new ItensPedidoResultDTO
            {
                Id = i.Id,
                IdProduto = i.IdProduto,
                NomeProduto = i.Produto.NomeProduto,
                ValorUnitario = i.Produto.Valor,
                Quantidade = i.Quantidade
            })
        };

        return result;
    }

    public async Task Add(PedidoDTO request, CancellationToken token)
    {
        var pedido = _mapper.Map<Pedido>(request);

        pedido.DataCriacao = DateTime.Now;

        await _unitOfWork.ExecuteTransactionAsync(async () => await _unitOfWork.PedidoRepository.AddAsync(pedido), token);
    }

    public async Task Update(Pedido request, CancellationToken token)
    {
        var pedido = await _unitOfWork.PedidoRepository.FirstOrDefaultAsync(x => x.Id == request.Id);
        await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.PedidoRepository.Update(pedido), token);
    }

    public async Task Delete(int id, CancellationToken token)
    {
        var pedido = await _unitOfWork.PedidoRepository.FirstOrDefaultAsync(x => x.Id == id);
        await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.PedidoRepository.Delete(pedido), token);
    }
}

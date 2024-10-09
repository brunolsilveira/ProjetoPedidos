namespace ProjPedidos.Application.Common.Models.Pedido;

public class PedidoResultDTO
{
    public int Id { get; set; }
    public string NomeCliente { get; set; } = string.Empty;
    public string EmailCliente { get; set; } = string.Empty;
    public bool Pago { get; set; }
    public decimal ValorTotal { get; set; }

    public IEnumerable<ItensPedidoResultDTO> ItensPedido { get; set; }
}

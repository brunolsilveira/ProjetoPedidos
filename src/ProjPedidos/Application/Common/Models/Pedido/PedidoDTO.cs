namespace ProjPedidos.Application.Common.Models.Pedido;

public class PedidoDTO
{
    public string NomeCliente { get; set; } = string.Empty;
    public string EmailCliente { get; set; } = string.Empty;
    public bool Pago { get; set; }

    public IEnumerable<ItensPedidoDTO> ItensPedido { get; set; }
}

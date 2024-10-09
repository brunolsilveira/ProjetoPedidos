using ProjPedidos.Application.Common.Models;

namespace ProjPedidos.Domain.Entities;

public class Pedido : BaseModel
{
    public string NomeCliente { get; set; } = string.Empty;
    public string EmailCliente { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; }
    public bool Pago { get; set; }

    public virtual ICollection<ItensPedido> ItensPedido { get; set; }
}

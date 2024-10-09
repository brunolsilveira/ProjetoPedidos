using System.ComponentModel.DataAnnotations.Schema;
using ProjPedidos.Application.Common.Models;

namespace ProjPedidos.Domain.Entities;

public class ItensPedido : BaseModel
{
    public int Quantidade { get; set; }
    [ForeignKey(nameof(Pedido))]
    public int IdPedido { get; set; }
    public virtual Pedido Pedido { get; set; }
    [ForeignKey(nameof(Produto))]
    public int IdProduto { get; set; }
    public virtual Produto Produto { get; set; }
}

using System.ComponentModel.DataAnnotations;
using ProjPedidos.Application.Common.Models;

namespace ProjPedidos.Domain.Entities;

public class Produto : BaseModel
{
    public string NomeProduto { get; set; } = string.Empty;
    public decimal Valor { get; set; }

    public virtual ICollection<ItensPedido> ItensPedido { get; set; }
}

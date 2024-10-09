using Microsoft.EntityFrameworkCore;

namespace ProjPedidos.Web.Extensions;
/// <summary>
/// Seeding data by ModelBuilder
/// </summary>
public static class ModelBuilderExtension
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produto>().HasData(
            new Produto
            {
                Id = 1,
                NomeProduto = "Produto 1",
                Valor = 19.99M
            },
            new Produto
            {
                Id = 2,
                NomeProduto = "Produto 2",
                Valor = 29.99M
            },
            new Produto
            {
                Id = 3,
                NomeProduto = "Produto 3",
                Valor = 39.99M
            },
            new Produto
            {
                Id = 4,
                NomeProduto = "Produto 4",
                Valor = 49.99M
            },
            new Produto
            {
                Id = 5,
                NomeProduto = "Produto 5",
                Valor = 59.99M
            }
        );

        modelBuilder.Entity<ItensPedido>().HasData(
           new ItensPedido
           {
               Id = 1,
               Quantidade = 1,
               IdPedido = 1,
               IdProduto = 1,
           },
           new ItensPedido
           {
               Id = 2,
               Quantidade = 2,
               IdPedido = 1,
               IdProduto = 2,
           },
           new ItensPedido
           {
               Id = 3,
               Quantidade = 12,
               IdPedido = 2,
               IdProduto = 3,
           },
           new ItensPedido
           {
               Id = 4,
               Quantidade = 1,
               IdPedido = 2,
               IdProduto = 4,
           },
           new ItensPedido
           {
               Id = 5,
               Quantidade = 1,
               IdPedido = 3,
               IdProduto = 1,
           }
       );


        modelBuilder.Entity<Pedido>().HasData(
           new Pedido
           {
               Id = 1,
               NomeCliente  = "Cliente 1",
               EmailCliente = "Email 1",
               DataCriacao = new DateTime(2024, 10, 1),
               Pago = true,
           },
           new Pedido
           {
               Id = 2,
               NomeCliente = "Cliente 2",
               EmailCliente = "Email 2",
               DataCriacao = new DateTime(2024, 10, 2),
               Pago = true,
           },
           new Pedido
           {
               Id = 3,
               NomeCliente = "Cliente 3",
               EmailCliente = "Email 3",
               DataCriacao = new DateTime(2024, 10, 3),
               Pago = true,
           },
           new Pedido
           {
               Id = 4,
               NomeCliente = "Cliente 4",
               EmailCliente = "Email 4",
               DataCriacao = new DateTime(2024, 10, 4),
               Pago = false,
           },
           new Pedido
           {
               Id = 5,
               NomeCliente = "Cliente 5",
               EmailCliente = "Email 5",
               DataCriacao = new DateTime(2024, 10, 5),
               Pago = false,
           }
       );
    }
}

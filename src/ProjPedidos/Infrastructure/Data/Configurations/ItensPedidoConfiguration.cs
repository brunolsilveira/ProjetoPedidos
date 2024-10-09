using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjPedidos.Infrastructure.Data.Configurations;

public class ItensPedidoConfiguration : IEntityTypeConfiguration<ItensPedido>
{
    public void Configure(EntityTypeBuilder<ItensPedido> builder)
    {
        builder.ToTable("ItensPedido");

        //Id
        builder.HasKey(x => x.Id);

        //builder.HasOne<Pedido>()
        //   .WithMany()
        //   .HasForeignKey(x => x.IdPedido);

        //builder.HasOne<Produto>()
        //   .WithMany()
        //   .HasForeignKey(x => x.IdProduto);
    }
}

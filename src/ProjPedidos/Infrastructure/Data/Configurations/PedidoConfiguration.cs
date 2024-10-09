using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjPedidos.Infrastructure.Data.Configurations;

public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.ToTable("Pedido");

        //Id
        builder.HasKey(x => x.Id);

        builder.Property(b => b.NomeCliente).HasColumnType("nvarchar(60)");

        builder.Property(b => b.EmailCliente).HasColumnType("nvarchar(60)");
    }
}

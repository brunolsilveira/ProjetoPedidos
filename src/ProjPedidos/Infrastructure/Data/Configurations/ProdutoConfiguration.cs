using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjPedidos.Infrastructure.Data.Configurations;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produto");

        //Id
        builder.HasKey(x => x.Id);

        builder.Property(b => b.NomeProduto).HasColumnType("nvarchar(20)");

        builder.Property(b => b.Valor).HasPrecision(10, 2);
    }
}

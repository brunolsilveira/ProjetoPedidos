using System.Reflection;
using ProjPedidos.Web.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ProjPedidos.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<ItensPedido> ItensPedido { get; set; }
    public DbSet<Produto> Produto { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.Seed();
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestApi.Entities;
using RestApi.Enums;

namespace RestApi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos => Set<Producto>();

        public DbSet<Movimientos> MovimientosStock => Set<Movimientos>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Producto>()
                .ToTable("Productos")
                .HasIndex(p => p.Codigo)
                .IsUnique();

            builder.Entity<Producto>()
                .Property(p => p.PrecioUnitario)
                .HasPrecision(18, 2);

            builder.Entity<Producto>()
                .HasMany(p => p.StockMovements)
                .WithOne(m => m.Product)
                .HasForeignKey(m => m.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Movimientos>()
                .ToTable("MovimientosStock");
        }
    }
}

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

        public DbSet<Producto> Products => Set<Producto>();

        public DbSet<Movimientos> StockMovements => Set<Movimientos>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Producto>()
                .HasIndex(p => p.Codigo)
                .IsUnique();

            builder.Entity<Producto>()
                .Property(p => p.PrecioUnitario)
                .HasPrecision(18, 2);
        }
    }
}

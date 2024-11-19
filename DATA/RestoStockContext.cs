using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using RestoStockDB.Models;

namespace RestoStockDB.DATA
{
    public class RestoStockContext : DbContext
    {
<<<<<<< HEAD

        // Constructor que recibe DbContextOptions
        public RestoStockContext(DbContextOptions<RestoStockContext> options)
            : base(options)
        {
        }


        public DbSet<DetallePlato> DetallesPlato { get; set; }
=======
        public DbSet<DetallesPlato> DetallesPlatos { get; set; }
>>>>>>> Sofia
        public DbSet<Ingredientes> Ingrediente { get; set; }
        public DbSet<Pedidos> Pedido { get; set; }
        public DbSet<Proveedores> Proveedor { get; set; }
        public DbSet<Platos> Plato { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\mssqllocaldb;Database=RestoStockDB;Trusted_Connection=True;");
            }
        }
    }
}

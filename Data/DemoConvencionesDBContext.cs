using buscadorWebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace buscadorWebApi.Models
{
    public class DemoConvencionesDBContext : DbContext
    {
        public DemoConvencionesDBContext(DbContextOptions<DemoConvencionesDBContext> options) : base(options)
        {

        }

        public DbSet<etiquetas> etiquetas { get; set; }
        public DbSet<titulos> titulos { get; set; }
        public DbSet<entradas> entradas { get; set; }
        public DbSet<fuentes> fuentes { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using PPIChallenge.Models;

namespace PPIChallenge.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {
        
        }

        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Activo> Activos { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Estado> Estados { get; set; }
    }
}

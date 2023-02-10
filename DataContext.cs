using Fenix.Models;
using Microsoft.EntityFrameworkCore;

namespace Fenix
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : 
            base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Cidade> Cidades { get; set; }
    }
}

using Janos.Models;
using Microsoft.EntityFrameworkCore;

namespace Janos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Loja> Lojas { get; set; }
        public DbSet<Nota> Notas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseOracle("User Id=myUsername;Password=myPassword;Data Source=myOracleDB");
            }
        }
    }
}

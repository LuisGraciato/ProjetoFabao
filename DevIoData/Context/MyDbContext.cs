using DevIoBusiness.Models;
using Microsoft.EntityFrameworkCore;

namespace DevIoData.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ReceitaEntrada> ReceitasEntrada { get; set; }
        public DbSet<ReceitaSaida> ReceitasSaida { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasKey(c => c.Id);
            modelBuilder.Entity<ReceitaEntrada>().HasKey(r => r.Id);
            modelBuilder.Entity<ReceitaSaida>().HasKey(rs => rs.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}




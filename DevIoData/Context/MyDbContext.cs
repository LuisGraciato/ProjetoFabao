using DevIoBusiness.Models;
using Microsoft.EntityFrameworkCore;

namespace DevIoData.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}




using Microsoft.EntityFrameworkCore;
using sithecAPI.Models;

namespace sithecAPI.Data
{
    public class HumanoContext : DbContext
    {
        public HumanoContext()
        {
        }
        public HumanoContext(DbContextOptions<HumanoContext> options) : base(options)
        {
        }

        public DbSet<Humano> Humanos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Humano>().ToTable("Humano");
        }
    }
}

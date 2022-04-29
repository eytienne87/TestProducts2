using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class PostgresContext : DbContext
    {
        public PostgresContext(DbContextOptions<PostgresContext> opt) : base(opt)
        {
        }

        public DbSet<ColorName> ColorNames { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ColorName>().HasKey(cn => new { cn.ProductType, cn.ColorCode });
        }
    }
}

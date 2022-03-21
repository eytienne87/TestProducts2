using Microsoft.EntityFrameworkCore;
using TestProducts2.Models;

namespace TestProducts2.Data
{
    public class SqlServerContext : DbContext
        {
            public SqlServerContext(DbContextOptions<SqlServerContext> opt) : base(opt)
            {
            }

            public DbSet<Product> Products { get; set; } = default!;
            public DbSet<WarrantyTitle> WarrantiesTitles { get; set; } = default!;
            public DbSet<WarrantyLength> WarrantiesLengths { get; set; } = default!;
            public DbSet<WarrantyNotabene> WarrantiesNotabenes { get; set; } = default!;
            public DbSet<ProductWarranty> ProductWarranties { get; set; } = default!;

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                //modelBuilder.Entity<ProductWarranty>()
                //    .HasKey(cw => new { cw.ProductId, cw.WarrantyTitleId });
                //modelBuilder.Entity<ProductWarranty>()
                //    .HasOne(c => c.Product)
                //    .WithMany(pw => pw.ProductWarranties)
                //    .HasForeignKey(p => p.ProductId);              
                //modelBuilder.Entity<ProductWarranty>()
                //    .HasOne(w => w.WarrantyTitle)
                //    .WithMany(cw => cw.ProductWarranties)
                //    .HasForeignKey(w => w.ProductId);  
            
                modelBuilder.Entity<ProductBenefit>()
                    .HasKey(cw => new { cw.ProductId, cw.BenefitId });
                modelBuilder.Entity<ProductBenefit>()
                    .HasOne(c => c.Product)
                    .WithMany(pw => pw.ProductBenefits)
                    .HasForeignKey(p => p.ProductId);              
                modelBuilder.Entity<ProductBenefit>()
                    .HasOne(w => w.Benefit)
                    .WithMany(cw => cw.ProductBenefits)
                    .HasForeignKey(w => w.ProductId);  
            }
    }
}

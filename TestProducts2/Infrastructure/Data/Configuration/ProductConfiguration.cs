using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasAlternateKey(p => new
            {
                p.ProductType,
                p.StyleCode,
                p.BackingCode,
                p.Width,
                p.MarketingProgram,
                p.ColorCode
            });

            builder.Navigation(p => p.Abrasion).AutoInclude();
            builder.Navigation(p => p.Benefits).AutoInclude();
            builder.Navigation(p => p.Warranties).AutoInclude();

            builder.HasMany(p => p.Benefits)
                   .WithMany(b => b.Products)
                   .UsingEntity(join => join.ToTable("ProductsBenefits"));
            builder.HasMany(p => p.Warranties)
                   .WithMany(w => w.Products)
                   .UsingEntity(join => join.ToTable("ProductsWarranties"));

            builder.Property(p => p.Width).HasColumnType("decimal(3,2)");
        }
    }
}

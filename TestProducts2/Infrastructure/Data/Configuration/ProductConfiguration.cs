using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Navigation(p => p.Abrasion).AutoInclude();
            builder.Navigation(p => p.Benefits).AutoInclude();
            builder.Navigation(p => p.Warranties).AutoInclude();

            builder.HasMany(p => p.Benefits)
                   .WithMany(b => b.Products)
                   .UsingEntity(join => join.ToTable("ProductsBenefits"));
        }
    }
}

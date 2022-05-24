using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    internal class BenefitConfiguration : IEntityTypeConfiguration<Benefit>
    {
        public void Configure(EntityTypeBuilder<Benefit> builder)
        {
            builder.Navigation(b => b.Descriptions).AutoInclude();
            builder.Navigation(b => b.Category).AutoInclude();
            builder.Navigation(b => b.MarketSegments).AutoInclude();
        }
    }
}

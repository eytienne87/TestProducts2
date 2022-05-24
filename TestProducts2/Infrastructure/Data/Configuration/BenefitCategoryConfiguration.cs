using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    internal class BenefitCategoryConfiguration : IEntityTypeConfiguration<BenefitCategory>
    {
        public void Configure(EntityTypeBuilder<BenefitCategory> builder)
        {
            builder.Navigation(x => x.Descriptions).AutoInclude();
        }
    }
}

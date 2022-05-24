using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    internal class BenefitCategoryDescriptionConfiguration : IEntityTypeConfiguration<BenefitCategoryDescription>
    {
        public void Configure(EntityTypeBuilder<BenefitCategoryDescription> builder)
        {
            builder.HasKey(x => new { x.CategoryOfBenefitId, x.Language });
        }
    }
}

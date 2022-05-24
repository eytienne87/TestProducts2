using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    internal class BenefitDescriptionConfiguration : IEntityTypeConfiguration<BenefitDescription>
    {
        public void Configure(EntityTypeBuilder<BenefitDescription> builder)
        {
            builder.HasKey(x => new { x.BenefitId, x.Language });
        }
    }
}

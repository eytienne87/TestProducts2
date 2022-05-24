using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    internal class WarrantyTitleDescriptionConfiguration : IEntityTypeConfiguration<WarrantyTitleDescription>
    {
        public void Configure(EntityTypeBuilder<WarrantyTitleDescription> builder)
        {
            builder.HasKey(x => new { x.WarrantyTitleId, x.Language });
        }
    }
}

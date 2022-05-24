using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    internal class WarrantyNotabeneDescriptionConfiguration : IEntityTypeConfiguration<WarrantyNotabeneDescription>
    {
        public void Configure(EntityTypeBuilder<WarrantyNotabeneDescription> builder)
        {
            builder.HasKey(x => new { x.WarrantyNotabeneId, x.Language });
        }
    }
}

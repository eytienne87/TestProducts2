using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    internal class WarrantyLengthDescriptionConfiguration : IEntityTypeConfiguration<WarrantyLengthDescription>
    {
        public void Configure(EntityTypeBuilder<WarrantyLengthDescription> builder)
        {
            builder.HasKey(x => new { x.WarrantyLengthId, x.Language });
        }
    }
}

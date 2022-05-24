using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    internal class AbrasionResistanceDescriptionConfiguration : IEntityTypeConfiguration<AbrasionResistanceDescription>
    {
        public void Configure(EntityTypeBuilder<AbrasionResistanceDescription> builder)
        {
            builder.HasKey(x => new { x.AbrasionResistanceId, x.Language });
        }
    }
}

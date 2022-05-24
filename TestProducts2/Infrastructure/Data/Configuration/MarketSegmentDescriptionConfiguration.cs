using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    internal class MarketSegmentDescriptionConfiguration : IEntityTypeConfiguration<MarketSegmentDescription>
    {
        public void Configure(EntityTypeBuilder<MarketSegmentDescription> builder)
        {
            builder.HasKey(x => new { x.MarketSegmentId, x.Language });
        }
    }
}

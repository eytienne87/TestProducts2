using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    internal class MarketSegmentConfiguration : IEntityTypeConfiguration<MarketSegment>
    {
        public void Configure(EntityTypeBuilder<MarketSegment> builder)
        {
            builder.Navigation(x => x.Descriptions).AutoInclude();
        }
    }
}

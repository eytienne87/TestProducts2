using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    internal class WarrantyConfiguration : IEntityTypeConfiguration<Warranty>
    {
        public void Configure(EntityTypeBuilder<Warranty> builder)
        {
            builder.Navigation(w => w.WarrantyTitle).AutoInclude();
            builder.Navigation(w => w.WarrantyLength).AutoInclude();
            builder.Navigation(w => w.WarrantyNotabene).AutoInclude();
        }
    }
}

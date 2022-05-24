using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    internal class WarrantyLengthConfiguration : IEntityTypeConfiguration<WarrantyLength>
    {
        public void Configure(EntityTypeBuilder<WarrantyLength> builder)
        {
            builder.Navigation(x => x.Descriptions).AutoInclude();
        }
    }
}

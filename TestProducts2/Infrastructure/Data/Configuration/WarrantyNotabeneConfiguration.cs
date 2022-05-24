using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    internal class WarrantyNotabeneConfiguration : IEntityTypeConfiguration<WarrantyNotabene>
    {
        public void Configure(EntityTypeBuilder<WarrantyNotabene> builder)
        {
            builder.Navigation(x => x.Descriptions).AutoInclude();
        }
    }
}

using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    internal class WarrantyTitleConfiguration : IEntityTypeConfiguration<WarrantyTitle>
    {
        public void Configure(EntityTypeBuilder<WarrantyTitle> builder)
        {
            builder.Navigation(x => x.Descriptions).AutoInclude();
        }
    }
}

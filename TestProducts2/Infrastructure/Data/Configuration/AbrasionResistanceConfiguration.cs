using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    internal class AbrasionResistanceConfiguration : IEntityTypeConfiguration<AbrasionResistance>
    {
        public void Configure(EntityTypeBuilder<AbrasionResistance> builder)
        {
            builder.Navigation(x => x.Descriptions).AutoInclude();
        }
    }
}

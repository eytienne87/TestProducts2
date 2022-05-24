using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> opt) : base(opt)
        {
        }

        public DbSet<AbrasionResistance> AbrasionResistances { get; set; } = default!;
        public DbSet<AbrasionResistanceDescription> AbrasionResistanceDescriptions { get; set; } = default!;
        public DbSet<Benefit> Benefits { get; set; } = default!;
        public DbSet<BenefitDescription> BenefitDescriptions { get; set; } = default!;
        public DbSet<BenefitCategory> BenefitCategories { get; set; } = default!;
        public DbSet<BenefitCategoryDescription> BenefitCategoryDescriptions { get; set; } = default!;
        public DbSet<MarketSegment> MarketSegments { get; set; } = default!;
        public DbSet<MarketSegmentDescription> MarketSegmentDescriptions { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Warranty> Warranties { get; set; } = default!;
        public DbSet<WarrantyLength> WarrantyLengths { get; set; } = default!;
        public DbSet<WarrantyLengthDescription> WarrantyLengthDescriptions { get; set; } = default!;
        public DbSet<WarrantyNotabene> WarrantyNotabenes { get; set; } = default!;
        public DbSet<WarrantyNotabeneDescription> WarrantyNotabeneDescriptions { get; set; } = default!;
        public DbSet<WarrantyTitle> WarrantyTitles { get; set; } = default!;
        public DbSet<WarrantyTitleDescription> WarrantyTitleDescriptions { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlServerContext).Assembly);
        }

        //public override int SaveChanges()
        //{
        //    var entries = ChangeTracker
        //                        .Entries()
        //                        .Where(e => e.Entity is BaseClass && (
        //                                e.State == EntityState.Added
        //                                || e.State == EntityState.Modified));

        //    foreach (var entityEntry in entries)
        //    {
        //        ((BaseClass)entityEntry.Entity).UpdatedDate = DateTime.Now.ToUniversalTime();

        //        if (entityEntry.State == EntityState.Added)
        //        {
        //            ((BaseClass)entityEntry.Entity).CreatedDate = DateTime.Now.ToUniversalTime();
        //        }
        //    }

        //    return base.SaveChanges();
        //}   
    }
}

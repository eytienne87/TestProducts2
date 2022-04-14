using Microsoft.EntityFrameworkCore;
using TestProducts2.Domain.Models;
using TestProducts2.Entities;


namespace TestProducts2.Data
{
    public class SqlServerContext : DbContext
        {
            public SqlServerContext(DbContextOptions<SqlServerContext> opt) : base(opt)
            {
            }

            public DbSet<Product> Products { get; set; } = default!;
            public DbSet<Benefit> Benefits { get; set; } = default!;
            public DbSet<CategoryOfBenefit> CategoryOfBenefits { get; set; } = default!;
            public DbSet<Warranty> Warranties { get; set; } = default!;
            public DbSet<WarrantyTitle> WarrantyTitles { get; set; } = default!;
            public DbSet<WarrantyLength> WarrantyLengths { get; set; } = default!;
            public DbSet<WarrantyNotabene> WarrantyNotabenes { get; set; } = default!;
            public DbSet<MarketSegment> MarketSegments { get; set; } = default!;
                
        
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                                        // ----- Autoinclude -----

                //Products
                modelBuilder.Entity<Product>().Navigation(p => p.Benefits).AutoInclude();
                modelBuilder.Entity<Product>().Navigation(p => p.Warranties).AutoInclude();

                //Benefits
                modelBuilder.Entity<Benefit>().Navigation(b => b.Descriptions).AutoInclude();
                modelBuilder.Entity<Benefit>().Navigation(b => b.Category).AutoInclude();
                modelBuilder.Entity<Benefit>().Navigation(b => b.MarketSegments).AutoInclude();

                //Category of Benefits
                modelBuilder.Entity<CategoryOfBenefit>().Navigation(cb => cb.Descriptions).AutoInclude();

                //Warranties
                modelBuilder.Entity<Warranty>().Navigation(w => w.WarrantyTitle).AutoInclude();
                modelBuilder.Entity<Warranty>().Navigation(w => w.WarrantyLength).AutoInclude();
                modelBuilder.Entity<Warranty>().Navigation(w => w.WarrantyNotabene).AutoInclude();

                //Warranty Title
                modelBuilder.Entity<WarrantyTitle>().Navigation(wt => wt.Descriptions).AutoInclude();
                
                //Warranty Length
                modelBuilder.Entity<WarrantyLength>().Navigation(wt => wt.Descriptions).AutoInclude();                
                
                //Warranty Notabene
                modelBuilder.Entity<WarrantyNotabene>().Navigation(wt => wt.Descriptions).AutoInclude();
            
                //Market Segment
                modelBuilder.Entity<MarketSegment>().Navigation(ms => ms.Descriptions).AutoInclude();
                
                
                                        // ----- Unique Keys -----

                //BenefitDescription
                modelBuilder.Entity<BenefitDescription>().HasKey(bd => new { bd.BenefitId, bd.Language });
                
                //WarrantyTitleDescription
                modelBuilder.Entity<WarrantyTitleDescription>().HasKey(wt => new { wt.WarrantyTitleId, wt.Language });
                
                //WarrantyLengthDescription
                modelBuilder.Entity<WarrantyLengthDescription>().HasKey(wl => new { wl.WarrantyLengthId, wl.Language });
            
                //WarrantyNotabeneDescription
                modelBuilder.Entity<WarrantyNotabeneDescription>().HasKey(wn => new { wn.WarrantyNotabeneId, wn.Language });
            
                //MarketSegmentDescription
                modelBuilder.Entity<MarketSegmentDescription>().HasKey(ms => new { ms.MarketSegmentId, ms.Language });
            
                //CategoryOfBenefitDescription
                modelBuilder.Entity<CategoryOfBenefitDescription>().HasKey(bc => new { bc.CategoryOfBenefitId, bc.Language });

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

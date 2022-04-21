using Domain.Base;
using Domain.Models;
using Domain.Shared;
using Infrastructure;

namespace API.Common
{
    public class DataSeeder : BaseClass
    {
        private readonly SqlServerContext _context;

        public DataSeeder(SqlServerContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.Products.Any())
            {
                var products = new HashSet<Product>()
                {
                    new Product()
                    {
                        ProductType = "Redwood Laminate",
                        StyleCode = "1234",
                        StyleName = "Wood",
                        Benefits = new HashSet<Benefit>()
                        {
                            new Benefit {
                                ProductType = "1",
                                Descriptions = new HashSet<BenefitDescription>()
                                {
                                    new BenefitDescription() { Language = LanguageClass.en, Description = "Really Convenient and easy to assemble" },
                                    new BenefitDescription() { Language = LanguageClass.fr, Description = "Très pratique et facile à assembler" }
                                },
                                MarketSegments = new HashSet<MarketSegment>()
                                {
                                    new MarketSegment() {
                                        UrlName = "/residential",
                                        Descriptions = new HashSet<MarketSegmentDescription>()
                                        {
                                            new MarketSegmentDescription { Language = LanguageClass.en, Description = "Residential"  },
                                            new MarketSegmentDescription { Language = LanguageClass.fr, Description = "Résidentiel"  }
                                        },
                                    },
                                    new MarketSegment() {
                                        UrlName = "/government",
                                        Descriptions = new HashSet<MarketSegmentDescription>()
                                        {
                                            new MarketSegmentDescription { Language = LanguageClass.en, Description = "Government"  },
                                            new MarketSegmentDescription { Language = LanguageClass.fr, Description = "Gouvernement"  }
                                        },
                                    },
                                },
                                Category = new CategoryOfBenefit {
                                    Descriptions = new HashSet<CategoryOfBenefitDescription>()
                                    {
                                        new CategoryOfBenefitDescription { Language = LanguageClass.en, Description = "Easy" },
                                        new CategoryOfBenefitDescription { Language = LanguageClass.fr, Description = "Facile" }
                                    },
                                    CreatedDate = DateTime.Now,
                                    UpdatedDate = DateTime.Today.AddDays(1)
                                },
                                CreatedDate = DateTime.Now,
                                UpdatedDate = DateTime.Today.AddDays(1)
                            },
                            //new Benefit {
                            //    ProductType = "2",
                            //    Descriptions = new HashSet<BenefitDescription>()
                            //    {
                            //        new BenefitDescription() { Language = LanguageClass.en, Description = "Will last for many decades" },
                            //        new BenefitDescription() { Language = LanguageClass.fr, Description = "Va durer plusieurs décennies" }
                            //    },
                            //    MarketSegments = new HashSet<MarketSegment>()
                            //    {
                            //        new MarketSegment() {
                            //            UrlName = "/commercial",
                            //            Descriptions = new HashSet<MarketSegmentDescription>()
                            //            {
                            //                new MarketSegmentDescription { Language = LanguageClass.en, Description = "Commercial" },
                            //                new MarketSegmentDescription { Language = LanguageClass.fr, Description = "Entreprise" }
                            //            },
                            //        },
                            //        new MarketSegment() {
                            //            UrlName = "/sportsfacility",
                            //            Descriptions = new HashSet<MarketSegmentDescription>()
                            //            {
                            //                new MarketSegmentDescription { Language = LanguageClass.en, Description = "Sports Facility" },
                            //                new MarketSegmentDescription { Language = LanguageClass.fr, Description = "Centre Sportif" }
                            //            },
                            //        },
                            //    },
                            //    Category = new CategoryOfBenefit {
                            //        Descriptions = new HashSet<CategoryOfBenefitDescription>()
                            //        {
                            //            new CategoryOfBenefitDescription { Language = LanguageClass.en, Description = "Lasting" },
                            //            new CategoryOfBenefitDescription { Language = LanguageClass.fr, Description = "Endurant" }
                            //        },
                            //        CreatedDate = DateTime.Now,
                            //        UpdatedDate = DateTime.Today.AddDays(1)
                            //    },
                            //    CreatedDate = DateTime.Now,
                            //    UpdatedDate = DateTime.Today.AddDays(1)
                            //}
                        },
                        Warranties = new HashSet<Warranty>()
                        {
                            new Warranty {
                                WarrantyTitle = new WarrantyTitle {
                                    Descriptions = new HashSet<WarrantyTitleDescription>()
                                    {
                                        new WarrantyTitleDescription { Language = LanguageClass.en, Description = "Wear"  },
                                        new WarrantyTitleDescription { Language = LanguageClass.fr, Description = "Usure"  }
                                    },
                                    CreatedDate = DateTime.Now,
                                    UpdatedDate = DateTime.Today.AddDays(1)
                                },
                                WarrantyLength = new WarrantyLength {
                                    Descriptions = new HashSet<WarrantyLengthDescription>()
                                    {
                                        new WarrantyLengthDescription { Language = LanguageClass.en, Description = "5 years" },
                                        new WarrantyLengthDescription { Language = LanguageClass.fr, Description = "5 ans" }
                                    },
                                    CreatedDate = DateTime.Now,
                                    UpdatedDate = DateTime.Today.AddDays(1)
                                },
                                WarrantyNotabene = new WarrantyNotabene {
                                    Descriptions = new HashSet<WarrantyNotabeneDescription>()
                                    {
                                        new WarrantyNotabeneDescription { Language = LanguageClass.en, Description = "An example of Notabene" },
                                        new WarrantyNotabeneDescription { Language = LanguageClass.fr, Description = "Un exemple de Notabene" }
                                    },
                                    CreatedDate = DateTime.Now,
                                    UpdatedDate = DateTime.Today.AddDays(1)
                                },
                            },
                        },
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Today.AddDays(1)
                    },
                    //new Product()
                    //{
                    //    ProductType = "Grey Carpet",
                    //    StyleCode = "5678",
                    //    StyleName = "Carpet",
                    //    Benefits = new HashSet<Benefit>()
                    //    {
                    //        new Benefit {
                    //            ProductType = "2",
                    //            Descriptions = new HashSet<BenefitDescription>()
                    //            {
                    //                new BenefitDescription() { Language = LanguageClass.en, Description = "Really Convenient and easy to assemble" },
                    //                new BenefitDescription() { Language = LanguageClass.fr, Description = "Très pratique et facile à assembler" }
                    //            },
                    //            MarketSegments = new HashSet<MarketSegment>()
                    //            {
                    //                new MarketSegment() {
                    //                    UrlName = "/commercial",
                    //                    Descriptions = new HashSet<MarketSegmentDescription>()
                    //                    {
                    //                        new MarketSegmentDescription { Language = LanguageClass.en, Description = "Commercial" },
                    //                        new MarketSegmentDescription { Language = LanguageClass.fr, Description = "Entreprise" }
                    //                    },
                    //                },
                    //                new MarketSegment() {
                    //                    UrlName = "/sportsfacility",
                    //                    Descriptions = new HashSet<MarketSegmentDescription>()
                    //                    {
                    //                        new MarketSegmentDescription { Language = LanguageClass.en, Description = "Sports Facility" },
                    //                        new MarketSegmentDescription { Language = LanguageClass.fr, Description = "Centre Sportif" }
                    //                    },
                    //                },
                    //            },
                    //            Category = new CategoryOfBenefit {
                    //                Descriptions = new HashSet<CategoryOfBenefitDescription>()
                    //                {
                    //                    new CategoryOfBenefitDescription { Language = LanguageClass.en, Description = "Easy" },
                    //                    new CategoryOfBenefitDescription { Language = LanguageClass.fr, Description = "Facile" }
                    //                },
                    //                CreatedDate = DateTime.Now,
                    //                UpdatedDate = DateTime.Today.AddDays(1)
                    //            },
                    //            CreatedDate = DateTime.Now,
                    //            UpdatedDate = DateTime.Today.AddDays(1)
                    //        },
                    //        new Benefit {
                    //            ProductType = "1",
                    //            Descriptions = new HashSet<BenefitDescription>()
                    //            {
                    //                new BenefitDescription() { Language = LanguageClass.en, Description = "Will last for many decades" },
                    //                new BenefitDescription() { Language = LanguageClass.fr, Description = "Va durer plusieurs décennies" }
                    //            },
                    //            MarketSegments = new HashSet<MarketSegment>()
                    //            {
                    //                new MarketSegment() {
                    //                    UrlName = "/residential",
                    //                    Descriptions = new HashSet<MarketSegmentDescription>()
                    //                    {
                    //                        new MarketSegmentDescription { Language = LanguageClass.en, Description = "Residential" },
                    //                        new MarketSegmentDescription { Language = LanguageClass.fr, Description = "Résidentiel" }
                    //                    },
                    //                },
                    //                new MarketSegment() {
                    //                    UrlName = "/government",
                    //                    Descriptions = new HashSet<MarketSegmentDescription>()
                    //                    {
                    //                        new MarketSegmentDescription { Language = LanguageClass.en, Description = "Government" },
                    //                        new MarketSegmentDescription { Language = LanguageClass.fr, Description = "Gouvernement" }
                    //                    },
                    //                },
                    //            },
                    //            Category = new CategoryOfBenefit {
                    //                Descriptions = new HashSet<CategoryOfBenefitDescription>()
                    //                {
                    //                    new CategoryOfBenefitDescription { Language = LanguageClass.en, Description = "Lasting" },
                    //                    new CategoryOfBenefitDescription { Language = LanguageClass.fr, Description = "Endurant" }
                    //                },
                    //                CreatedDate = DateTime.Now,
                    //                UpdatedDate = DateTime.Today.AddDays(1)
                    //            },
                    //            CreatedDate = DateTime.Now,
                    //            UpdatedDate = DateTime.Today.AddDays(1)
                    //        }
                    //    },
                    //    Warranties = new HashSet<Warranty>()
                    //    {
                    //        new Warranty {
                    //            WarrantyTitle = new WarrantyTitle {
                    //                Descriptions = new HashSet<WarrantyTitleDescription>()
                    //                {
                    //                    new WarrantyTitleDescription { Language = LanguageClass.en, Description = "Tear" },
                    //                    new WarrantyTitleDescription { Language = LanguageClass.fr, Description = "Brisure" }
                    //                },
                    //                CreatedDate = DateTime.Now,
                    //                UpdatedDate = DateTime.Today.AddDays(1)
                    //            },
                    //            WarrantyLength = new WarrantyLength {
                    //                Descriptions = new HashSet<WarrantyLengthDescription>()
                    //                {
                    //                    new WarrantyLengthDescription { Language = LanguageClass.en, Description = "25 years" },
                    //                    new WarrantyLengthDescription { Language = LanguageClass.fr, Description = "25 ans" }
                    //                },
                    //                CreatedDate = DateTime.Now,
                    //                UpdatedDate = DateTime.Today.AddDays(1)
                    //            },
                    //            WarrantyNotabene = new WarrantyNotabene {
                    //                Descriptions = new HashSet<WarrantyNotabeneDescription>()
                    //                {
                    //                    new WarrantyNotabeneDescription { Language = LanguageClass.en, Description = "A second example" },
                    //                    new WarrantyNotabeneDescription { Language = LanguageClass.fr, Description = "Un deuxieme exemple" }
                    //                },
                    //                CreatedDate = DateTime.Now,
                    //                UpdatedDate = DateTime.Today.AddDays(1)
                    //            },
                    //            CreatedDate = DateTime.Now,
                    //            UpdatedDate = DateTime.Today.AddDays(1)
                    //        },
                    //    },
                    //    CreatedDate = DateTime.Now,
                    //    UpdatedDate = DateTime.Today.AddDays(1)
                    //},
                };
                _context.Products.AddRange(products);
                _context.SaveChanges();
            }
        }
    }
}
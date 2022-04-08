using TestProducts2.Data;
using TestProducts2.Entities;

namespace TestProducts2.Models
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
                var products = new List<Product>()
                {
                    new Product()
                    {
                        ProductType = "Redwood Laminate",
                        StyleCode = "1234",
                        StyleName = "Wood",
                        Benefits = new List<Benefit>()
                        {
                            new Benefit {
                                Descriptions = new List<BenefitDescription>()
                                {
                                    new BenefitDescription() { Language = LanguageClass.en, Description = "Convenient" },
                                    new BenefitDescription() { Language = LanguageClass.fr, Description = "Utile" }
                                },
                                MarketSegments = new List<MarketSegment>()
                                {
                                    new MarketSegment() {
                                        UrlName = "/residential",
                                        Descriptions = new List<MarketSegmentDescription>()
                                        {
                                            new MarketSegmentDescription { Language = LanguageClass.en, Description = "Residential"  },
                                            new MarketSegmentDescription { Language = LanguageClass.fr, Description = "Résidentiel"  }
                                        },
                                    },
                                    new MarketSegment() {
                                        UrlName = "/government",
                                        Descriptions = new List<MarketSegmentDescription>()
                                        {
                                            new MarketSegmentDescription { Language = LanguageClass.en, Description = "Government"  },
                                            new MarketSegmentDescription { Language = LanguageClass.fr, Description = "Gouvernement"  }
                                        },
                                    },
                                },
                                CreatedDate = DateTime.Now,
                                UpdatedDate = DateTime.Today.AddDays(1)
                            },
                            new Benefit {
                                Descriptions = new List<BenefitDescription>()
                                {
                                    new BenefitDescription() { Language = LanguageClass.en, Description = "Lasting" },
                                    new BenefitDescription() { Language = LanguageClass.fr, Description = "Endurant" }
                                },
                                MarketSegments = new List<MarketSegment>()
                                {
                                    new MarketSegment() { 
                                        UrlName = "/commercial",
                                        Descriptions = new List<MarketSegmentDescription>() 
                                        {
                                            new MarketSegmentDescription { Language = LanguageClass.en, Description = "Commercial" },
                                            new MarketSegmentDescription { Language = LanguageClass.fr, Description = "Entreprise" }
                                        },     
                                    },
                                    new MarketSegment() { 
                                        UrlName = "/sportsfacility",
                                        Descriptions = new List<MarketSegmentDescription>() 
                                        {
                                            new MarketSegmentDescription { Language = LanguageClass.en, Description = "Sports Facility" },
                                            new MarketSegmentDescription { Language = LanguageClass.fr, Description = "Centre Sportif" }
                                        },     
                                    },
                                },
                                CreatedDate = DateTime.Now,
                                UpdatedDate = DateTime.Today.AddDays(1)
                            }
                        },
                        Warranties = new List<Warranty>()
                        {
                            new Warranty {
                                WarrantyTitle = new WarrantyTitle {
                                    Descriptions = new List<WarrantyTitleDescription>()
                                    {
                                        new WarrantyTitleDescription { Language = LanguageClass.en, Description = "Wear"  },
                                        new WarrantyTitleDescription { Language = LanguageClass.fr, Description = "Usure"  }
                                    },
                                    CreatedDate = DateTime.Now,
                                    UpdatedDate = DateTime.Today.AddDays(1)
                                },
                                WarrantyLength = new WarrantyLength {
                                    Descriptions = new List<WarrantyLengthDescription>()
                                    {
                                        new WarrantyLengthDescription { Language = LanguageClass.en, Description = "5 years" },
                                        new WarrantyLengthDescription { Language = LanguageClass.fr, Description = "5 ans" }
                                    },
                                    CreatedDate = DateTime.Now,
                                    UpdatedDate = DateTime.Today.AddDays(1)
                                },
                                WarrantyNotabene = new WarrantyNotabene {
                                    Descriptions = new List<WarrantyNotabeneDescription>()
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
                    new Product()
                    {
                        ProductType = "Grey Carpet",
                        StyleCode = "5678",
                        StyleName = "Carpet",
                        Benefits = new List<Benefit>()
                        {
                            new Benefit {
                                Descriptions = new List<BenefitDescription>()
                                {
                                    new BenefitDescription() { Language = LanguageClass.en, Description = "Convenient" },
                                    new BenefitDescription() { Language = LanguageClass.fr, Description = "Utile" }
                                },
                                MarketSegments = new List<MarketSegment>()
                                {
                                    new MarketSegment() {
                                        UrlName = "/commercial",
                                        Descriptions = new List<MarketSegmentDescription>()
                                        {
                                            new MarketSegmentDescription { Language = LanguageClass.en, Description = "Commercial" },
                                            new MarketSegmentDescription { Language = LanguageClass.fr, Description = "Entreprise" }
                                        },
                                    },
                                    new MarketSegment() {
                                        UrlName = "/sportsfacility",
                                        Descriptions = new List<MarketSegmentDescription>()
                                        {
                                            new MarketSegmentDescription { Language = LanguageClass.en, Description = "Sports Facility" },
                                            new MarketSegmentDescription { Language = LanguageClass.fr, Description = "Centre Sportif" }
                                        },
                                    },
                                },
                                CreatedDate = DateTime.Now,
                                UpdatedDate = DateTime.Today.AddDays(1)
                            },
                            new Benefit {
                                Descriptions = new List<BenefitDescription>()
                                {
                                    new BenefitDescription() { Language = LanguageClass.en, Description = "Lasting" },
                                    new BenefitDescription() { Language = LanguageClass.fr, Description = "Endurant" }
                                },
                                MarketSegments = new List<MarketSegment>()
                                {
                                    new MarketSegment() {
                                        UrlName = "/residential",
                                        Descriptions = new List<MarketSegmentDescription>()
                                        {
                                            new MarketSegmentDescription { Language = LanguageClass.en, Description = "Residential"  },
                                            new MarketSegmentDescription { Language = LanguageClass.fr, Description = "Résidentiel"  }
                                        },
                                    },
                                    new MarketSegment() {
                                        UrlName = "/government",
                                        Descriptions = new List<MarketSegmentDescription>()
                                        {
                                            new MarketSegmentDescription { Language = LanguageClass.en, Description = "Government"  },
                                            new MarketSegmentDescription { Language = LanguageClass.fr, Description = "Gouvernement"  }
                                        },
                                    },
                                },
                                CreatedDate = DateTime.Now,
                                UpdatedDate = DateTime.Today.AddDays(1)
                            }
                        },
                        Warranties = new List<Warranty>()
                        {
                            new Warranty {
                                WarrantyTitle = new WarrantyTitle {
                                    Descriptions = new List<WarrantyTitleDescription>()
                                    {
                                        new WarrantyTitleDescription { Language = LanguageClass.en, Description = "Tear" },
                                        new WarrantyTitleDescription { Language = LanguageClass.fr, Description = "Brisure" }
                                    },
                                    CreatedDate = DateTime.Now,
                                    UpdatedDate = DateTime.Today.AddDays(1)
                                },
                                WarrantyLength = new WarrantyLength {
                                    Descriptions = new List<WarrantyLengthDescription>()
                                    {
                                        new WarrantyLengthDescription { Language = LanguageClass.en, Description = "25 years" },
                                        new WarrantyLengthDescription { Language = LanguageClass.fr, Description = "25 ans" }
                                    },
                                    CreatedDate = DateTime.Now,
                                    UpdatedDate = DateTime.Today.AddDays(1)
                                },
                                WarrantyNotabene = new WarrantyNotabene {
                                    Descriptions = new List<WarrantyNotabeneDescription>()
                                    {
                                        new WarrantyNotabeneDescription { Language = LanguageClass.en, Description = "A second example" },
                                        new WarrantyNotabeneDescription { Language = LanguageClass.fr, Description = "Un deuxieme exemple" }
                                    },
                                    CreatedDate = DateTime.Now,
                                    UpdatedDate = DateTime.Today.AddDays(1)
                                },
                                CreatedDate = DateTime.Now,
                                UpdatedDate = DateTime.Today.AddDays(1)
                            },
                        },
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Today.AddDays(1)
                    },
                };
                _context.Products.AddRange(products);
                _context.SaveChanges();
            }
        }
    }
}
namespace API.Common
{
    public class Mapper
    {
        //public static ProductReadDto Map(Product product)
        //{
        //    return new ProductReadDto
        //    {
        //        ProductType = product.ProductType,
        //        StyleCode = product.StyleCode,
        //        StyleName = product.StyleName,
        //        Benefits = product.Benefits.Select(productBenefit => new BenefitReadDto
        //        {
        //            Id = productBenefit.Id,
        //            ProductType = productBenefit.ProductType,
        //            Category = productBenefit.Category != null ? new BenefitCategoryReadDto
        //            {
        //                Id = productBenefit.Category.Id,
        //                Descriptions = productBenefit.Category.Descriptions?.Select(productBenefitCategoryDescription => new CategoryOfBenefitDescriptionReadDto
        //                {
        //                    Language = productBenefitCategoryDescription.Language,
        //                    Description = productBenefitCategoryDescription.Description
        //                }).ToList()
        //            } : null,
        //            MarketSegments = productBenefit.MarketSegments?.Select(productBenefitMarketSegment => new MarketSegmentReadDto
        //            {
        //                Id = productBenefitMarketSegment.Id,
        //                Descriptions = productBenefitMarketSegment.Descriptions.Select(productBenefitMarketSegmentDescription => new MarketSegmentDescriptionReadDto
        //                {
        //                    Language = productBenefitMarketSegmentDescription.Language,
        //                    Description = productBenefitMarketSegmentDescription.Description
        //                }).ToList()
        //            }).ToList(),
        //            Descriptions = productBenefit.Descriptions?.Select(productBenefitDescription => new BenefitDescriptionReadDto
        //            {
        //                Language = productBenefitDescription.Language,
        //                Description = productBenefitDescription.Description
        //            }).ToList() ?? throw new ArgumentNullException(nameof(productBenefit), "The value of 'productBenefit.Descriptions' should not be null")
        //        }).ToList(),
        //        Warranties = product.Warranties.Select(productWarranty => new WarrantyReadDto
        //        {
        //            WarrantyTitle = new WarrantyTitleReadDto
        //            {
        //                Id = productWarranty.WarrantyTitle.Id,
        //                Descriptions = productWarranty.WarrantyTitle.Descriptions.Select(productWarrantyWarrantyTitleDescription => new WarrantyTitleDescriptionReadDto
        //                {
        //                    Language = productWarrantyWarrantyTitleDescription.Language,
        //                    Description = productWarrantyWarrantyTitleDescription.Description
        //                }).ToList()
        //            },
        //            WarrantyLength = new WarrantyLengthReadDto
        //            {
        //                Id = productWarranty.WarrantyLength.Id,
        //                Descriptions = productWarranty.WarrantyLength.Descriptions.Select(productWarrantyWarrantyLengthDescription => new WarrantyLengthDescriptionReadDto
        //                {
        //                    Language = productWarrantyWarrantyLengthDescription.Language,
        //                    Description = productWarrantyWarrantyLengthDescription.Description
        //                }).ToList()
        //            },
        //            WarrantyNotabene = productWarranty.WarrantyNotabene != null ? new WarrantyNotabeneReadDto
        //            {
        //                Id = productWarranty.WarrantyNotabene.Id,
        //                Descriptions = productWarranty.WarrantyNotabene.Descriptions.Select(productWarrantyWarrantyNotabeneDescription => new WarrantyNotabeneDescriptionReadDto
        //                {
        //                    Description = productWarrantyWarrantyNotabeneDescription.Description,
        //                    Language = productWarrantyWarrantyNotabeneDescription.Language
        //                }).ToList()
        //            } : throw new ArgumentNullException(nameof(productWarranty), "The value of 'productWarranty.WarrantyNotabene' should not be null")
        //        }).ToList()
        //    };
        //}
    }
}

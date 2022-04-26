namespace API.Services.Abstractions
{
    public interface IServiceManager
    {
        IAbrasionResistanceService AbrasionResistanceService { get; }
        IBenefitService BenefitService { get; }
        ICategoryOfBenefitService CategoryOfBenefitService { get; }
        IMarketSegmentService MarketSegmentService { get; }
        IMiniService MiniService { get; }
        IProductService ProductService { get; }
        IWarrantyTitleService WarrantyTitleService { get; }
        IWarrantyLengthService WarrantyLengthService { get; }
        IWarrantyNotabeneService WarrantyNotabeneService { get; }
    }
}

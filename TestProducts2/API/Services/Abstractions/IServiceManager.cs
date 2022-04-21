namespace API.Services.Abstractions
{
    public interface IServiceManager
    {
        IBenefitService BenefitService { get; }
        ICategoryOfBenefitService CategoryOfBenefitService { get; }
        IMarketSegmentService MarketSegmentService { get; }
        IProductService ProductService { get; }
        IWarrantyTitleService WarrantyTitleService { get; }
        IWarrantyLengthService WarrantyLengthService { get; }
        IWarrantyNotabeneService WarrantyNotabeneService { get; }
    }
}

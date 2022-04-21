using API.Services.Abstractions;
using AutoMapper;
using Domain.Interfaces;

namespace API.Services.Implementations
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBenefitService> _benefitService;
        private readonly Lazy<ICategoryOfBenefitService> _categoryOfBenefitService;
        private readonly Lazy<IMarketSegmentService> _marketSegmentService;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IWarrantyTitleService> _warrantyTitleService;
        private readonly Lazy<IWarrantyLengthService> _warrantyLengthService;
        private readonly Lazy<IWarrantyNotabeneService> _warrantyNotabeneService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _benefitService = new Lazy<IBenefitService>(() => new BenefitService(repositoryManager, mapper));
            _categoryOfBenefitService = new Lazy<ICategoryOfBenefitService>(() => new CategoryOfBenefitService(repositoryManager, mapper));
            _marketSegmentService = new Lazy<IMarketSegmentService>(() => new MarketSegmentService(repositoryManager, mapper));
            _productService = new Lazy<IProductService>(() => new ProductService(repositoryManager, mapper));
            _warrantyTitleService = new Lazy<IWarrantyTitleService>(() => new WarrantyTitleService(repositoryManager, mapper));
            _warrantyLengthService = new Lazy<IWarrantyLengthService>(() => new WarrantyLengthService(repositoryManager, mapper));
            _warrantyNotabeneService = new Lazy<IWarrantyNotabeneService>(() => new WarrantyNotabeneService(repositoryManager, mapper));
        }

        public IBenefitService BenefitService => _benefitService.Value;
        public ICategoryOfBenefitService CategoryOfBenefitService => _categoryOfBenefitService.Value;
        public IMarketSegmentService MarketSegmentService => _marketSegmentService.Value;
        public IProductService ProductService => _productService.Value;
        public IWarrantyTitleService WarrantyTitleService => _warrantyTitleService.Value;
        public IWarrantyLengthService WarrantyLengthService => _warrantyLengthService.Value;
        public IWarrantyNotabeneService WarrantyNotabeneService => _warrantyNotabeneService.Value;
    }
}

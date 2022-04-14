using TestProducts2.Domain.Models;


namespace TestProducts2.Data
{
    public class RepositoryManager : IRepositoryManager
    {
        private Lazy<IProductRepository> _productRepository;
        private Lazy<IRepository<Benefit>> _benefitRepository;
        private Lazy<IRepository<CategoryOfBenefit>> _categoryOfBenefitRepository;
        private Lazy<IRepository<MarketSegment>> _marketSegmentRepository;
        private Lazy<IRepository<Warranty>> _warrantyRepository;
        private Lazy<IRepository<WarrantyTitle>> _warrantyTitleRepository;
        private Lazy<IRepository<WarrantyLength>> _warrantyLengthRepository;
        private Lazy<IRepository<WarrantyNotabene>> _warrantyNotabeneRepository;
        private Lazy<IUnitOfWork> _unitOfWork;


        public RepositoryManager(SqlServerContext sqlServerContext)
        {
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(sqlServerContext));
            _benefitRepository = new Lazy<IRepository<Benefit>>(() => new GenericRepository<Benefit>(sqlServerContext));
            _categoryOfBenefitRepository = new Lazy<IRepository<CategoryOfBenefit>>(() => new GenericRepository<CategoryOfBenefit>(sqlServerContext));
            _marketSegmentRepository = new Lazy<IRepository<MarketSegment>>(() => new GenericRepository<MarketSegment>(sqlServerContext));
            _warrantyRepository = new Lazy<IRepository<Warranty>>(() => new GenericRepository<Warranty>(sqlServerContext));
            _warrantyTitleRepository = new Lazy<IRepository<WarrantyTitle>>(() => new GenericRepository<WarrantyTitle>(sqlServerContext));
            _warrantyLengthRepository = new Lazy<IRepository<WarrantyLength>>(() => new GenericRepository<WarrantyLength>(sqlServerContext));
            _warrantyNotabeneRepository = new Lazy<IRepository<WarrantyNotabene>>(() => new GenericRepository<WarrantyNotabene>(sqlServerContext));
            _unitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(sqlServerContext));
        }

        public IProductRepository ProductRepository => _productRepository.Value;
        public IRepository<Benefit> BenefitRepository => _benefitRepository.Value;
        public IRepository<CategoryOfBenefit> CategoryOfBenefitRepository => _categoryOfBenefitRepository.Value;
        public IRepository<MarketSegment> MarketSegmentRepository => _marketSegmentRepository.Value;
        public IRepository<Warranty> WarrantyRepository => _warrantyRepository.Value;
        public IRepository<WarrantyTitle> WarrantyTitleRepository => _warrantyTitleRepository.Value;
        public IRepository<WarrantyLength> WarrantyLengthRepository => _warrantyLengthRepository.Value;
        public IRepository<WarrantyNotabene> WarrantyNotabeneRepository => _warrantyNotabeneRepository.Value;
        public IUnitOfWork UnitOfWork => _unitOfWork.Value;

        //public IProductRepository ProductRepository
        //{
        //    get
        //    {
        //        if (_productRepository is null)
        //        {
        //            _productRepository = new ProductRepository(_sqlServerContext);
        //        }

        //        return _productRepository.Value;
        //    }
        //}
    }
}

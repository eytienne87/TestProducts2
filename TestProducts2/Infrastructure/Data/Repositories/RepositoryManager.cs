using Domain.Interfaces;
using Domain.Models;

namespace Infrastructure.Data.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IRepository<AbrasionResistance>> _abrasionResistanceRepository;
        private readonly Lazy<IRepository<Benefit>> _benefitRepository;
        private readonly Lazy<IRepository<CategoryOfBenefit>> _categoryOfBenefitRepository;
        private readonly Lazy<IRepository<MarketSegment>> _marketSegmentRepository;
        private readonly Lazy<IRepository<Product>> _productRepository;
        private readonly Lazy<IRepository<Warranty>> _warrantyRepository;
        private readonly Lazy<IRepository<WarrantyTitle>> _warrantyTitleRepository;
        private readonly Lazy<IRepository<WarrantyLength>> _warrantyLengthRepository;
        private readonly Lazy<IRepository<WarrantyNotabene>> _warrantyNotabeneRepository;
        private readonly Lazy<IUnitOfWork> _unitOfWork;
        private readonly Lazy<IRepository<ColorName>> _colorNameRepository;


        public RepositoryManager(SqlServerContext sqlServerContext, PostgresContext postgresContext)
        {
            _abrasionResistanceRepository = new Lazy<IRepository<AbrasionResistance>>(() => new GenericRepository<AbrasionResistance>(sqlServerContext));
            _benefitRepository = new Lazy<IRepository<Benefit>>(() => new GenericRepository<Benefit>(sqlServerContext));
            _categoryOfBenefitRepository = new Lazy<IRepository<CategoryOfBenefit>>(() => new GenericRepository<CategoryOfBenefit>(sqlServerContext));
            _marketSegmentRepository = new Lazy<IRepository<MarketSegment>>(() => new GenericRepository<MarketSegment>(sqlServerContext));
            _productRepository = new Lazy<IRepository<Product>>(() => new GenericRepository<Product>(sqlServerContext));
            _warrantyRepository = new Lazy<IRepository<Warranty>>(() => new GenericRepository<Warranty>(sqlServerContext));
            _warrantyTitleRepository = new Lazy<IRepository<WarrantyTitle>>(() => new GenericRepository<WarrantyTitle>(sqlServerContext));
            _warrantyLengthRepository = new Lazy<IRepository<WarrantyLength>>(() => new GenericRepository<WarrantyLength>(sqlServerContext));
            _warrantyNotabeneRepository = new Lazy<IRepository<WarrantyNotabene>>(() => new GenericRepository<WarrantyNotabene>(sqlServerContext));
            _unitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(sqlServerContext));
            _colorNameRepository = new Lazy<IRepository<ColorName>>(() => new GenericRepository<ColorName>(postgresContext));
        }    
        public RepositoryManager(SqlServerContext sqlServerContext)
        {
            _abrasionResistanceRepository = new Lazy<IRepository<AbrasionResistance>>(() => new GenericRepository<AbrasionResistance>(sqlServerContext));
            _benefitRepository = new Lazy<IRepository<Benefit>>(() => new GenericRepository<Benefit>(sqlServerContext));
            _categoryOfBenefitRepository = new Lazy<IRepository<CategoryOfBenefit>>(() => new GenericRepository<CategoryOfBenefit>(sqlServerContext));
            _marketSegmentRepository = new Lazy<IRepository<MarketSegment>>(() => new GenericRepository<MarketSegment>(sqlServerContext));
            _productRepository = new Lazy<IRepository<Product>>(() => new GenericRepository<Product>(sqlServerContext));
            _warrantyRepository = new Lazy<IRepository<Warranty>>(() => new GenericRepository<Warranty>(sqlServerContext));
            _warrantyTitleRepository = new Lazy<IRepository<WarrantyTitle>>(() => new GenericRepository<WarrantyTitle>(sqlServerContext));
            _warrantyLengthRepository = new Lazy<IRepository<WarrantyLength>>(() => new GenericRepository<WarrantyLength>(sqlServerContext));
            _warrantyNotabeneRepository = new Lazy<IRepository<WarrantyNotabene>>(() => new GenericRepository<WarrantyNotabene>(sqlServerContext));
            _unitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(sqlServerContext));
        }

        public IRepository<AbrasionResistance> AbrasionResistanceRepository => _abrasionResistanceRepository.Value;
        public IRepository<Benefit> BenefitRepository => _benefitRepository.Value;
        public IRepository<CategoryOfBenefit> CategoryOfBenefitRepository => _categoryOfBenefitRepository.Value;
        public IRepository<MarketSegment> MarketSegmentRepository => _marketSegmentRepository.Value;
        public IRepository<Product> ProductRepository => _productRepository.Value;
        public IRepository<Warranty> WarrantyRepository => _warrantyRepository.Value;
        public IRepository<WarrantyTitle> WarrantyTitleRepository => _warrantyTitleRepository.Value;
        public IRepository<WarrantyLength> WarrantyLengthRepository => _warrantyLengthRepository.Value;
        public IRepository<WarrantyNotabene> WarrantyNotabeneRepository => _warrantyNotabeneRepository.Value;
        public IUnitOfWork UnitOfWork => _unitOfWork.Value;

        public IRepository<ColorName> ColorNameRepository => _colorNameRepository.Value;

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

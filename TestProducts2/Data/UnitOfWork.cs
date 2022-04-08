using TestProducts2.Models;

namespace TestProducts2.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlServerContext _sqlServerContext;
        private IProductRepository? _productRepository;
        private IRepository<Benefit>? _benefitRepository;
        private IRepository<CategoryOfBenefit>? _categoryOfBenefitRepository;
        private IRepository<Warranty>? _warrantyRepository;
        private IRepository<WarrantyTitle>? _warrantyTitleRepository;
        private IRepository<WarrantyLength>? _warrantyLengthRepository;
        private IRepository<WarrantyNotabene>? _warrantyNotabeneRepository;
        private IRepository<MarketSegment>? _marketSegmentRepository;

        public UnitOfWork(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository is null)
                {
                    _productRepository = new ProductRepository(_sqlServerContext);
                }

                return _productRepository;
            }
        }
        public IRepository<Benefit> BenefitRepository
        {
            get
            {
                if (_benefitRepository is null)
                {
                    _benefitRepository = new GenericRepository<Benefit>(_sqlServerContext);
                }

                return _benefitRepository;
            }
        }

        public IRepository<Warranty> WarrantyRepository
        {
            get
            {
                if (_warrantyRepository is null)
                {
                    _warrantyRepository = new GenericRepository<Warranty>(_sqlServerContext);
                }

                return _warrantyRepository;
            }
        }
        public IRepository<WarrantyTitle> WarrantyTitleRepository
        {
            get
            {
                if (_warrantyTitleRepository is null)
                {
                    _warrantyTitleRepository = new GenericRepository<WarrantyTitle>(_sqlServerContext);
                }

                return _warrantyTitleRepository;
            }
        }

        public IRepository<WarrantyLength> WarrantyLengthRepository
        {
            get
            {
                if (_warrantyLengthRepository is null)
                {
                    _warrantyLengthRepository = new GenericRepository<WarrantyLength>(_sqlServerContext);
                }

                return _warrantyLengthRepository;
            }
        }
        
        public IRepository<WarrantyNotabene> WarrantyNotabeneRepository
        {
            get
            {
                if (_warrantyNotabeneRepository is null)
                {
                    _warrantyNotabeneRepository = new GenericRepository<WarrantyNotabene>(_sqlServerContext);
                }

                return _warrantyNotabeneRepository;
            }
        }
        public IRepository<MarketSegment> MarketSegmentRepository
        {
            get
            {
                if (_marketSegmentRepository is null)
                {
                    _marketSegmentRepository = new GenericRepository<MarketSegment>(_sqlServerContext);
                }

                return _marketSegmentRepository;
            }
        }
        
        public IRepository<CategoryOfBenefit> CategoryOfBenefitRepository
        {
            get
            {
                if (_categoryOfBenefitRepository is null)
                {
                    _categoryOfBenefitRepository = new GenericRepository<CategoryOfBenefit>(_sqlServerContext);
                }

                return _categoryOfBenefitRepository;
            }
        }

        public void Save()
        {
            if (_sqlServerContext.ChangeTracker.HasChanges()) _sqlServerContext.SaveChanges();
        }
    }
}

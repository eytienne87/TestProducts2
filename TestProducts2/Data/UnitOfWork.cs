using TestProducts2.Models;

namespace TestProducts2.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlServerContext _sqlServerContext;
        private IProductRepository? _productRepository;
        private IRepository<Benefit>? _benefitRepository;
        private IRepository<Warranty>? _warrantyRepository;
        private IRepository<WarrantyTitle>? _warrantyTitleRepository;
        private IRepository<WarrantyLength>? _warrantyLengthRepository;
        private IRepository<WarrantyNotabene>? _warrantyNotabeneRepository;

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

        public void Save()
        {
            if (_sqlServerContext.ChangeTracker.HasChanges()) _sqlServerContext.SaveChanges();
        }
    }
}

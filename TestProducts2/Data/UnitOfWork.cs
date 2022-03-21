using TestProducts2.Models;

namespace TestProducts2.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlServerContext _sqlServerContext;
        private IProductRepository<Product>? _productRepository;
        private IRepository<ProductWarranty>? _productWarrantyRepository;
        private IRepository<WarrantyTitle>? _warrantyTitleRepository;
        private IRepository<WarrantyLength>? _warrantyLengthRepository;
        private IRepository<Benefit>? _benefitRepository;
        private IRepository<WarrantyNotabene>? _warrantyNotabeneRepository;

        public UnitOfWork(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public IProductRepository<Product> ProductRepository
        {
            get
            {
                if (_productRepository is null)
                {
                    _productRepository = new ProductRepository<Product>(_sqlServerContext);
                }

                return _productRepository;
            }
        }
        public IRepository<ProductWarranty> ProductWarrantyRepository
        {
            get
            {
                if (_productWarrantyRepository is null)
                {
                    _productWarrantyRepository = new GenericRepository<ProductWarranty>(_sqlServerContext);
                }

                return _productWarrantyRepository;
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

        public void Save()
        {
            if (_sqlServerContext.ChangeTracker.HasChanges()) _sqlServerContext.SaveChanges();
        }
    }
}

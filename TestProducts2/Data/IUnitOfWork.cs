using TestProducts2.Models;

namespace TestProducts2.Data
{
    public interface IUnitOfWork
    {
        IProductRepository<Product> ProductRepository { get; }
        IRepository<ProductWarranty> ProductWarrantyRepository { get; }
        IRepository<WarrantyTitle> WarrantyTitleRepository { get; }
        IRepository<WarrantyLength> WarrantyLengthRepository { get; }
        IRepository<WarrantyNotabene> WarrantyNotabeneRepository { get; }
        IRepository<Benefit> BenefitRepository { get; }
        void Save();
    }
}

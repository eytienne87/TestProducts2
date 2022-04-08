using TestProducts2.Models;

namespace TestProducts2.Data
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IRepository<Benefit> BenefitRepository { get; }
        IRepository<Warranty> WarrantyRepository { get; }
        IRepository<WarrantyTitle> WarrantyTitleRepository { get; }
        IRepository<WarrantyLength> WarrantyLengthRepository { get; }
        IRepository<WarrantyNotabene> WarrantyNotabeneRepository { get; }
        IRepository<MarketSegment> MarketSegmentRepository { get; }
        void Save();
    }
}

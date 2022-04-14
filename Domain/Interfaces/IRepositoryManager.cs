using Domain.Models;

namespace Domain.Interfaces
{
    public interface IRepositoryManager
    {
        IProductRepository ProductRepository { get; }
        IRepository<Benefit> BenefitRepository { get; }
        IRepository<Warranty> WarrantyRepository { get; }
        IRepository<WarrantyTitle> WarrantyTitleRepository { get; }
        IRepository<WarrantyLength> WarrantyLengthRepository { get; }
        IRepository<WarrantyNotabene> WarrantyNotabeneRepository { get; }
        IRepository<MarketSegment> MarketSegmentRepository { get; }
        IRepository<CategoryOfBenefit> CategoryOfBenefitRepository { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}

using Domain.Models;

namespace Domain.Interfaces
{
    public interface IRepositoryManager
    {
        
        IRepository<AbrasionResistance> AbrasionResistanceRepository { get; }
        IRepository<Benefit> BenefitRepository { get; }
        IRepository<CategoryOfBenefit> CategoryOfBenefitRepository { get; }
        IRepository<MarketSegment> MarketSegmentRepository { get; }
        IRepository<Product> ProductRepository { get; }
        IRepository<Warranty> WarrantyRepository { get; }
        IRepository<WarrantyLength> WarrantyLengthRepository { get; }
        IRepository<WarrantyNotabene> WarrantyNotabeneRepository { get; }
        IRepository<WarrantyTitle> WarrantyTitleRepository { get; }
        IUnitOfWork UnitOfWork { get; }
        IRepository<ColorName> ColorNameRepository { get; }   
    }
}

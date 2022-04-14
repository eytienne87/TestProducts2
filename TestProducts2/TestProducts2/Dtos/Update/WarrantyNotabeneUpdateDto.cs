using Domain.Base;

namespace TestProducts2.Dtos.Update
{
    public class WarrantyNotabeneUpdateDto : BaseClass
    {
        public ICollection<WarrantyNotabeneDescriptionUpdateDto> Descriptions { get; set; } = new HashSet<WarrantyNotabeneDescriptionUpdateDto>();
    }
}

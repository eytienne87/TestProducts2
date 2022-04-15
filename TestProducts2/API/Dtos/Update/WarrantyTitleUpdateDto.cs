using Domain.Base;

namespace TestProducts2.Dtos.Update
{
    public class WarrantyTitleUpdateDto : BaseClass
    {
        public ICollection<WarrantyTitleDescriptionUpdateDto> Descriptions { get; set; } = new HashSet<WarrantyTitleDescriptionUpdateDto>();
    }
}

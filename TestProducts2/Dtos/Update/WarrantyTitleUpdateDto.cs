using TestProducts2.Entities;

namespace TestProducts2.Dtos.Update
{
    public class WarrantyTitleUpdateDto : BaseClass
    {
        public ICollection<WarrantyTitleDescriptionUpdateDto> Descriptions { get; set; }
    }
}

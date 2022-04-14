using TestProducts2.Entities;

namespace TestProducts2.Dtos.Update
{
    public class WarrantyNotabeneUpdateDto : BaseClass
    {
        public ICollection<WarrantyNotabeneDescriptionUpdateDto> Descriptions { get; set; }
    }
}

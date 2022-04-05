using TestProducts2.Entities;
using TestProducts2.Models;

namespace TestProducts2.Dtos
{
    public class BenefitUpdateDto : BaseClass
    {
        public ICollection<BenefitDescriptionUpdateDto>? Descriptions { get; set; }
    }
}
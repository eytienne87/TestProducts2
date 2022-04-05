using TestProducts2.Entities;
using TestProducts2.Models;

namespace TestProducts2.Dtos
{
    public class BenefitCreateDto : BaseClass
    {
        public ICollection<BenefitDescriptionCreateDto>? Descriptions { get; set; }
    }
}
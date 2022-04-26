using Domain.Base;

namespace API.Dtos.Update
{
    public class AbrasionResistanceUpdateDto : BaseClass
    {
        public string ProductType { get; set; } = string.Empty;
        public HashSet<AbrasionResistanceDescriptionUpdateDto>? Descriptions { get; set; }

    }
}
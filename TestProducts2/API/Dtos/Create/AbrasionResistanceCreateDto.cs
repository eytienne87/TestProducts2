using Domain.Base;

namespace API.Dtos.Create
{
    public class AbrasionResistanceCreateDto : BaseClass
    {
        public string ProductType { get; set; } = string.Empty;
        public HashSet<AbrasionResistanceDescriptionCreateDto>? Descriptions { get; set; }
    }
}
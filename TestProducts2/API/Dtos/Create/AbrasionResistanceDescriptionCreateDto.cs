using Domain.Shared;

namespace API.Dtos.Create
{
    public class AbrasionResistanceDescriptionCreateDto
    {
        public string Description { get; set; } = string.Empty;
        public LanguageClass Language { get; set; }
    }
}
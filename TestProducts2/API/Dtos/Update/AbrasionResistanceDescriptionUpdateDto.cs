using Domain.Shared;

namespace API.Dtos.Update
{
    public class AbrasionResistanceDescriptionUpdateDto
    {
        public LanguageClass Language { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
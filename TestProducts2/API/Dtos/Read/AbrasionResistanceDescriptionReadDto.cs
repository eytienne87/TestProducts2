using Domain.Shared;

namespace API.Dtos.Read
{
    public class AbrasionResistanceDescriptionReadDto
    {
        public LanguageClass Language { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
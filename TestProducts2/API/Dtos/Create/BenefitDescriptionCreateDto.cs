using Domain.Shared;

namespace API.Dtos.Create
{
    public class BenefitDescriptionCreateDto
    {
        public LanguageClass Language { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
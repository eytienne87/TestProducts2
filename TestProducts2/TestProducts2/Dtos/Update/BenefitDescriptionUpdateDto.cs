using Domain.Shared;

namespace TestProducts2.Dtos.Update
{
    public class BenefitDescriptionUpdateDto
    {
        public LanguageClass Language { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
using TestProducts2.Entities;

namespace TestProducts2.Dtos.Update
{
    public class BenefitDescriptionUpdateDto
    {
        public LanguageClass Language { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
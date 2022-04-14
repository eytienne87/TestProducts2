using Domain.Shared;


namespace TestProducts2.Dtos.Read
{
    public class BenefitDescriptionReadDto
    {
        public LanguageClass Language { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
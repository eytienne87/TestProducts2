using Domain.Shared;


namespace API.Dtos.Update
{
    public class CategoryOfBenefitDescriptionUpdateDto
    {
        public LanguageClass Language { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
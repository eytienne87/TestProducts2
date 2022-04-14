using Domain.Shared;

namespace Domain.Models
{
    public class CategoryOfBenefitDescription
    {
        public int CategoryOfBenefitId { get; set; }
        public LanguageClass Language { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
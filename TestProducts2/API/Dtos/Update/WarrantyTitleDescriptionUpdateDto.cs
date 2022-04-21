using Domain.Shared;

namespace API.Dtos.Update
{
    public class WarrantyTitleDescriptionUpdateDto
    {
        public LanguageClass Language { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}

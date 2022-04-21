using Domain.Shared;

namespace API.Dtos.Update
{
    public class WarrantyLengthDescriptionUpdateDto
    {
        public LanguageClass Language { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}

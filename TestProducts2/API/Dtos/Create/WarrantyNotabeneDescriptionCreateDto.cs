using Domain.Shared;

namespace API.Dtos.Create
{
    public class WarrantyNotabeneDescriptionCreateDto
    {
        public string Description { get; set; } = string.Empty;
        public LanguageClass Language { get; set; }
    }
}

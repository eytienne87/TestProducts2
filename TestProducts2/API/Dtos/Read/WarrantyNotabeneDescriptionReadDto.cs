using Domain.Shared;

namespace API.Dtos.Read
{
    public class WarrantyNotabeneDescriptionReadDto
    {
        public string Description { get; set; } = string.Empty;
        public LanguageClass Language { get; set; }
    }
}

using Domain.Shared;

namespace TestProducts2.Dtos.Update
{
    public class WarrantyNotabeneDescriptionUpdateDto
    {
        public LanguageClass Language { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}

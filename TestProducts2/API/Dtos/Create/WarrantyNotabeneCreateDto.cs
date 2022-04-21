namespace API.Dtos.Create
{
    public class WarrantyNotabeneCreateDto
    {
        public string ProductType { get; set; } = string.Empty;
        public ICollection<WarrantyNotabeneDescriptionCreateDto> Descriptions { get; set; } = new HashSet<WarrantyNotabeneDescriptionCreateDto>();
    }
}

namespace TestProducts2.Dtos.Create
{
    public class WarrantyTitleCreateDto
    {
        public string ProductType { get; set; } = string.Empty;
        public ICollection<WarrantyTitleDescriptionCreateDto> Descriptions { get; set; } = new HashSet<WarrantyTitleDescriptionCreateDto>();
    }
}

namespace TestProducts2.Dtos.Create
{
    public class WarrantyTitleCreateDto
    {
        public ICollection<WarrantyTitleDescriptionCreateDto> Descriptions { get; set; } = new HashSet<WarrantyTitleDescriptionCreateDto>();
    }
}

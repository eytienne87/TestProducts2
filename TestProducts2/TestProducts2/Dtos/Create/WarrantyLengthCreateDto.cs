namespace TestProducts2.Dtos.Create
{
    public class WarrantyLengthCreateDto
    {
        public ICollection<WarrantyLengthDescriptionCreateDto> Descriptions { get; set; } = new HashSet<WarrantyLengthDescriptionCreateDto>();
    }
}

namespace API.Dtos.Create
{
    public class WarrantyLengthCreateDto
    {
        public ICollection<WarrantyLengthDescriptionCreateDto> Descriptions { get; set; } = new HashSet<WarrantyLengthDescriptionCreateDto>();
    }
}

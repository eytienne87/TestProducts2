namespace API.Dtos.Read
{
    public class WarrantyTitleReadDto
    {
        public int Id { get; set; }
        public ICollection<WarrantyTitleDescriptionReadDto> Descriptions { get; set; } = new HashSet<WarrantyTitleDescriptionReadDto>();
    }
}

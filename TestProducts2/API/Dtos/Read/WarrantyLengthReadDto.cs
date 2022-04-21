namespace API.Dtos.Read
{
    public class WarrantyLengthReadDto
    {
        public int Id { get; set; }
        public ICollection<WarrantyLengthDescriptionReadDto> Descriptions { get; set; } = new HashSet<WarrantyLengthDescriptionReadDto>();
    }
}

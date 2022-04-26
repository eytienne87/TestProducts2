namespace API.Dtos.Read
{
    public class AbrasionResistanceReadDto
    {
        public int Id { get; set; }
        public string ProductType { get; set; } = string.Empty;
        public ICollection<AbrasionResistanceDescriptionReadDto> Descriptions { get; set; } = new HashSet<AbrasionResistanceDescriptionReadDto>();
    }
}

namespace API.Dtos.Read
{
    public class ProductReadDto
    {
        public int Id { get; set; }
        public string ProductType { get; set; } = string.Empty;
        public string StyleCode { get; set; } = string.Empty;
        public string StyleName { get; set; } = string.Empty;
        public AbrasionResistanceReadDto? Abrasion { get; set; }
        public ICollection<BenefitReadDto>? Benefits { get; set; }
        public ICollection<WarrantyReadDto>? Warranties { get; set; }
    }
}

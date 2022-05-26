namespace API.Dtos.Read
{
    public class ProductReadDto
    {
        public int Id { get; set; }
        public string ProductType { get; set; } = string.Empty;
        public string StyleCode { get; set; } = string.Empty;
        public string BackingCode { get; set; } = string.Empty;
        public string ColorCode { get; set; } = string.Empty;
        public string MarketingProgram { get; set; } = string.Empty;
        public decimal Width { get; set; } = decimal.Zero;
        public AbrasionResistanceReadDto? Abrasion { get; set; }
        public ICollection<BenefitReadDto>? Benefits { get; set; }
        public ICollection<WarrantyReadDto>? Warranties { get; set; }
        public ColorNameReadDto? ColorName { get; set; }
    }
}

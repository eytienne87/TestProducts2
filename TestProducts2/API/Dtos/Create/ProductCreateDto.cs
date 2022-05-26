using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Create
{
    public class ProductCreateDto : BaseClass
    {
        public string ProductType { get; set; } = string.Empty;
        public string StyleCode { get; set; } = string.Empty;
        public string BackingCode { get; set; } = string.Empty;
        public string ColorCode { get; set; } = string.Empty;
        public string MarketingProgram { get; set; } = string.Empty;
        public decimal Width { get; set; } = decimal.Zero;
        public HashSet<BenefitCreateDto>? Benefits { get; set; }
        public HashSet<WarrantyCreateDto>? Warranties { get; set; }
        public AbrasionResistanceCreateDto? Abrasion { get; set; }
        public int AbrasionId { get; set; }
    }
}
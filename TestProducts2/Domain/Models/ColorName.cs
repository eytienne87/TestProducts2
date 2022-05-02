using Domain.Base;

namespace Domain.Models
{
    public class ColorName : BaseClass
    {
        public string ProductType { get; set; } = string.Empty;
        public string StyleCode { get; set; } = string.Empty;
        public string ColorCode { get; set; } = string.Empty;
    }
}
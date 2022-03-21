using AutoMapper;
using TestProducts2.Dtos;
using TestProducts2.Models;

namespace TestProducts2.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductReadDto, Product>();
            CreateMap<ProductCreateDto, Product>();
            //CreateMap<Carpet, MiniReadDto>();

        }
    }
}

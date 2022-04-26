using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using AutoMapper;
using Domain.Models;


namespace API.Dtos.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductReadDto>()
                .ForMember(dest => dest.Benefits, opt => opt.MapFrom(src => src.Benefits))
                .ForMember(dest => dest.Warranties, opt => opt.MapFrom(src => src.Warranties))
                .ForMember(dest => dest.Abrasion, opt => opt.MapFrom(src => src.Abrasion));
            CreateMap<ProductReadDto, Product>();

            CreateMap<ProductCreateDto, Product>()
                .ForMember(dest => dest.Benefits, opt => opt.MapFrom(src => src.Benefits))
                .ForMember(dest => dest.Warranties, opt => opt.MapFrom(src => src.Warranties))
                .ForMember(dest => dest.Abrasion, opt => opt.MapFrom(src => new AbrasionResistance { Id = src.AbrasionId }));

            CreateMap<Product, ProductUpdateDto>()
                .ForMember(dest => dest.Benefits, opt => opt.MapFrom(src => src.Benefits))
                .ForMember(dest => dest.Warranties, opt => opt.MapFrom(src => src.Warranties));

            CreateMap<ProductUpdateDto, Product>()
                .ForMember(dest => dest.Benefits, opt => opt.MapFrom(src => src.Benefits))
                .ForMember(dest => dest.Warranties, opt => opt.MapFrom(src => src.Warranties))
                .ForMember(dest => dest.Abrasion, opt => opt.MapFrom(src => new AbrasionResistance { Id = src.AbrasionId }));

            CreateMap<Product, ProductMiniReadDto>()
                 .ForMember(dest => dest.Benefits, opt => opt.MapFrom(src => src.Benefits));
        }
    }
}

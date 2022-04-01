using AutoMapper;
using TestProducts2.Dtos;
using TestProducts2.Models;

namespace TestProducts2.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            //Products
            CreateMap<Product, ProductReadDto>()
                .ForMember(dest => dest.Benefits, opt => opt.MapFrom(src => src.Benefits))
                .ForMember(dest => dest.Warranties, opt => opt.MapFrom(src => src.Warranties));
            CreateMap<ProductReadDto, Product>();

            CreateMap<ProductCreateDto, Product>()
                .ForMember(dest => dest.Benefits, opt => opt.MapFrom(src => src.Benefits))
                .ForMember(dest => dest.Warranties, opt => opt.MapFrom(src => src.Warranties));

            CreateMap<ProductUpdateDto, Product>()
                .ForMember(dest => dest.Benefits, opt => opt.MapFrom(src => src.Benefits))
                .ForMember(dest => dest.Warranties, opt => opt.MapFrom(src => src.Warranties));

            //Benefits
            CreateMap<Benefit, BenefitReadDto>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));
            CreateMap<BenefitDescription, BenefitDescriptionReadDto>();
            CreateMap<BenefitCreateDto, Benefit>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));
            CreateMap<BenefitDescriptionCreateDto, BenefitDescription>();


            //Warranties
            CreateMap<Warranty, WarrantyReadDto>()
                .ForMember(dest => dest.WarrantyTitle, opt => opt.MapFrom(src => src.WarrantyTitle))
                .ForMember(dest => dest.WarrantyLength, opt => opt.MapFrom(src => src.WarrantyLength))
                .ForMember(dest => dest.WarrantyNotabene, opt => opt.MapFrom(src => src.WarrantyNotabene));
            CreateMap<WarrantyCreateDto, Warranty>()
                .ForMember(dest => dest.WarrantyTitle, opt => opt.MapFrom(src => new WarrantyTitle { Id = src.WarrantyTitleId }))
                .ForMember(dest => dest.WarrantyLength, opt => opt.MapFrom(src => new WarrantyLength { Id = src.WarrantyLengthId }))
                .ForMember(dest => dest.WarrantyNotabene, opt => opt.MapFrom(src => new WarrantyNotabene { Id = src.WarrantyNotabeneId }));


            //WarrantyTitle
            CreateMap<WarrantyTitleCreateDto, WarrantyTitle>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));
            CreateMap<WarrantyTitleDescriptionCreateDto, WarrantyTitleDescription>();

            CreateMap<WarrantyTitle, WarrantyTitleReadDto>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));
            CreateMap<WarrantyTitleDescription, WarrantyTitleDescriptionReadDto>();

            //WarrantyLength
            CreateMap<WarrantyLengthCreateDto, WarrantyLength>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));
            CreateMap<WarrantyLengthDescriptionCreateDto, WarrantyLengthDescription>();

            CreateMap<WarrantyLength, WarrantyLengthReadDto>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));
            CreateMap<WarrantyLengthDescription, WarrantyLengthDescriptionReadDto>();

            //WarrantyNotabene
            CreateMap<WarrantyNotabeneCreateDto, WarrantyNotabene>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));
            CreateMap<WarrantyNotabeneDescriptionCreateDto, WarrantyNotabeneDescription>();

            CreateMap<WarrantyNotabene, WarrantyNotabeneReadDto>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));
            CreateMap<WarrantyNotabeneDescription, WarrantyNotabeneDescriptionReadDto>();

        }
    }
}

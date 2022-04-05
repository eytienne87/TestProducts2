using AutoMapper;
using TestProducts2.Dtos;
using TestProducts2.Entities;
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
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom<DescriptionResolver<BenefitDescription, BenefitDescriptionReadDto>>());

            CreateMap<BenefitDescription, BenefitDescriptionReadDto>();

            CreateMap<BenefitCreateDto, Benefit>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));
            CreateMap<BenefitDescriptionCreateDto, BenefitDescription>();

            CreateMap<BenefitUpdateDto, Benefit>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));

            CreateMap<BenefitDescriptionUpdateDto, BenefitDescription>();

            //Warranties
            CreateMap<Warranty, WarrantyReadDto>()
                .ForMember(dest => dest.WarrantyTitle, opt => opt.MapFrom(src => src.WarrantyTitle))
                .ForMember(dest => dest.WarrantyLength, opt => opt.MapFrom(src => src.WarrantyLength))
                .ForMember(dest => dest.WarrantyNotabene, opt => opt.MapFrom(src => src.WarrantyNotabene));
            CreateMap<WarrantyCreateDto, Warranty>()
                .ForMember(dest => dest.WarrantyTitle, opt => opt.MapFrom(src => new WarrantyTitle { Id = src.WarrantyTitleId }))
                .ForMember(dest => dest.WarrantyLength, opt => opt.MapFrom(src => new WarrantyLength { Id = src.WarrantyLengthId }))
                .ForMember(dest => dest.WarrantyNotabene, opt => opt.MapFrom(src => new WarrantyNotabene { Id = src.WarrantyNotabeneId }));

            //WarrantyTitles
            CreateMap<WarrantyTitle, WarrantyTitleReadDto>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom<DescriptionResolver<WarrantyTitleDescription, WarrantyTitleDescriptionReadDto>>());
            CreateMap<WarrantyTitleDescription, WarrantyTitleDescriptionReadDto>();

            CreateMap<WarrantyTitleCreateDto, WarrantyTitle>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));
            CreateMap<WarrantyTitleDescriptionCreateDto, WarrantyTitleDescription>();
            
            CreateMap<WarrantyTitleUpdateDto, WarrantyTitle>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));

            CreateMap<WarrantyTitleDescriptionUpdateDto, WarrantyTitleDescription>();


            //WarrantyLengths
            CreateMap<WarrantyLength, WarrantyLengthReadDto>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom<DescriptionResolver<WarrantyLengthDescription, WarrantyLengthDescriptionReadDto>>());
            CreateMap<WarrantyLengthDescription, WarrantyLengthDescriptionReadDto>();

            CreateMap<WarrantyLengthCreateDto, WarrantyLength>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));
            CreateMap<WarrantyLengthDescriptionCreateDto, WarrantyLengthDescription>();
            
            CreateMap<WarrantyLengthUpdateDto, WarrantyLength>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));

            CreateMap<WarrantyLengthDescriptionUpdateDto, WarrantyLengthDescription>();


            //WarrantyNotabenes
            CreateMap<WarrantyNotabene, WarrantyNotabeneReadDto>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom<DescriptionResolver<WarrantyNotabeneDescription, WarrantyNotabeneDescriptionReadDto>>());
            CreateMap<WarrantyNotabeneDescription, WarrantyNotabeneDescriptionReadDto>();

            CreateMap<WarrantyNotabeneCreateDto, WarrantyNotabene>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));
            CreateMap<WarrantyNotabeneDescriptionCreateDto, WarrantyNotabeneDescription>();

            CreateMap<WarrantyNotabeneUpdateDto, WarrantyNotabene>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));

            CreateMap<WarrantyNotabeneDescriptionUpdateDto, WarrantyNotabeneDescription>();

        }
    }
}

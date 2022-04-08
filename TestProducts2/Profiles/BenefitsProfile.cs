using AutoMapper;
using TestProducts2.Dtos;
using TestProducts2.Entities;
using TestProducts2.Models;

namespace TestProducts2.Profiles
{
    public class BenefitsProfile : Profile
    {
        public BenefitsProfile()
        {
            CreateMap<Benefit, BenefitReadDto>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom<DescriptionResolver<BenefitDescription, BenefitDescriptionReadDto>>());

            CreateMap<BenefitDescription, BenefitDescriptionReadDto>();

            CreateMap<BenefitCreateDto, Benefit>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions))
                .ForMember(dest => dest.MarketSegments, opt => opt.MapFrom(src => src.MarketSegments))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));
            CreateMap<BenefitDescriptionCreateDto, BenefitDescription>();

            CreateMap<BenefitUpdateDto, Benefit>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));

            CreateMap<Benefit, BenefitUpdateDto>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));

            CreateMap<BenefitDescriptionUpdateDto, BenefitDescription>();
            CreateMap<BenefitDescription, BenefitDescriptionUpdateDto>();
        }
    }
}

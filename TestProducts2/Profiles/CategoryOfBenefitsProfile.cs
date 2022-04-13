using AutoMapper;
using TestProducts2.Dtos;
using TestProducts2.Entities;
using TestProducts2.Models;

namespace TestProducts2.Profiles
{
    public class CategoryOfBenefitsProfile : Profile
    {
        public CategoryOfBenefitsProfile()
        {
            CreateMap<CategoryOfBenefit, CategoryOfBenefitReadDto>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom<DescriptionResolver<CategoryOfBenefitDescription, CategoryOfBenefitDescriptionReadDto>>());

            CreateMap<CategoryOfBenefitDescription, CategoryOfBenefitDescriptionReadDto>();

            CreateMap<CategoryOfBenefitCreateDto, CategoryOfBenefit>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));
            CreateMap<CategoryOfBenefitDescriptionCreateDto, CategoryOfBenefitDescription>();

            CreateMap<CategoryOfBenefitUpdateDto, CategoryOfBenefit>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));
            CreateMap<CategoryOfBenefitDescriptionUpdateDto, CategoryOfBenefitDescription>();

            CreateMap<CategoryOfBenefit, CategoryOfBenefitUpdateDto>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));

            CreateMap<CategoryOfBenefitDescription, CategoryOfBenefitDescriptionUpdateDto>();

        }
    }
}

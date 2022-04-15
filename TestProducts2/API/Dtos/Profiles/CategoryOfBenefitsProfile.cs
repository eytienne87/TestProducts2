using AutoMapper;
using Domain.Models;
using TestProducts2.Dtos.Create;
using TestProducts2.Dtos.Read;
using TestProducts2.Dtos.Resolvers;
using TestProducts2.Dtos.Update;


namespace TestProducts2.Dtos.Profiles
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

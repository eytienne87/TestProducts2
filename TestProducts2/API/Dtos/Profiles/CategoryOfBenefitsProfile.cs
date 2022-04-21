using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Resolvers;
using API.Dtos.Update;
using AutoMapper;
using Domain.Models;


namespace API.Dtos.Profiles
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

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
            CreateMap<BenefitCategory, BenefitCategoryReadDto>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom<DescriptionResolver<BenefitCategoryDescription, CategoryOfBenefitDescriptionReadDto>>());

            CreateMap<BenefitCategoryDescription, CategoryOfBenefitDescriptionReadDto>();

            CreateMap<CategoryOfBenefitCreateDto, BenefitCategory>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));
            CreateMap<CategoryOfBenefitDescriptionCreateDto, BenefitCategoryDescription>();

            CreateMap<CategoryOfBenefitUpdateDto, BenefitCategory>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));
            CreateMap<CategoryOfBenefitDescriptionUpdateDto, BenefitCategoryDescription>();

            CreateMap<BenefitCategory, CategoryOfBenefitUpdateDto>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));

            CreateMap<BenefitCategoryDescription, CategoryOfBenefitDescriptionUpdateDto>();

        }
    }
}

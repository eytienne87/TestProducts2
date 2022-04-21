using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Resolvers;
using API.Dtos.Update;
using AutoMapper;
using Domain.Models;


namespace API.Dtos.Profiles
{
    public class WarrantyTitlesProfile : Profile
    {
        public WarrantyTitlesProfile()
        {
            CreateMap<WarrantyTitle, WarrantyTitleReadDto>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom<DescriptionResolver<WarrantyTitleDescription, WarrantyTitleDescriptionReadDto>>());
            CreateMap<WarrantyTitleDescription, WarrantyTitleDescriptionReadDto>();

            CreateMap<WarrantyTitleCreateDto, WarrantyTitle>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));
            CreateMap<WarrantyTitleDescriptionCreateDto, WarrantyTitleDescription>();

            CreateMap<WarrantyTitleUpdateDto, WarrantyTitle>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));

            CreateMap<WarrantyTitleDescriptionUpdateDto, WarrantyTitleDescription>();
        }
    }
}

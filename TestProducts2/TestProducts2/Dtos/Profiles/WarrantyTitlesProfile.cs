using AutoMapper;
using Domain.Models;
using TestProducts2.Dtos.Create;
using TestProducts2.Dtos.Read;
using TestProducts2.Dtos.Resolvers;
using TestProducts2.Dtos.Update;


namespace TestProducts2.Dtos.Profiles
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

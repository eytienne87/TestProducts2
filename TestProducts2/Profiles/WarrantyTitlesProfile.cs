using AutoMapper;
using TestProducts2.Dtos.Read;
using TestProducts2.Dtos.Update;
using TestProducts2.Entities;


namespace TestProducts2.Profiles
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

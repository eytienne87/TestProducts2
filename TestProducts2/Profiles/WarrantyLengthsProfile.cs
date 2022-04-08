using AutoMapper;
using TestProducts2.Dtos;
using TestProducts2.Entities;
using TestProducts2.Models;

namespace TestProducts2.Profiles
{
    public class WarrantyLengthsProfile : Profile
    {
        public WarrantyLengthsProfile()
        {
            CreateMap<WarrantyLength, WarrantyLengthReadDto>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom<DescriptionResolver<WarrantyLengthDescription, WarrantyLengthDescriptionReadDto>>());
            CreateMap<WarrantyLengthDescription, WarrantyLengthDescriptionReadDto>();

            CreateMap<WarrantyLengthCreateDto, WarrantyLength>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));
            CreateMap<WarrantyLengthDescriptionCreateDto, WarrantyLengthDescription>();
            
            CreateMap<WarrantyLengthUpdateDto, WarrantyLength>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));

            CreateMap<WarrantyLengthDescriptionUpdateDto, WarrantyLengthDescription>();
        }
    }
}

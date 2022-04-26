using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Resolvers;
using API.Dtos.Update;
using AutoMapper;
using Domain.Models;


namespace API.Dtos.Profiles
{
    public class AbrasionResistancesProfile : Profile
    {
        public AbrasionResistancesProfile()
        {
            CreateMap<AbrasionResistance, AbrasionResistanceReadDto>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom<DescriptionResolver<AbrasionResistanceDescription, AbrasionResistanceDescriptionReadDto>>());

            CreateMap<AbrasionResistanceDescription, AbrasionResistanceDescriptionReadDto>();

            CreateMap<AbrasionResistanceCreateDto, AbrasionResistance>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));
            CreateMap<AbrasionResistanceDescriptionCreateDto, AbrasionResistanceDescription>();

            CreateMap<AbrasionResistanceUpdateDto, AbrasionResistance>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));
            CreateMap<AbrasionResistanceDescriptionUpdateDto, AbrasionResistanceDescription>();

            CreateMap<AbrasionResistance, AbrasionResistanceUpdateDto>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));

            CreateMap<AbrasionResistanceDescription, AbrasionResistanceDescriptionUpdateDto>();

        }
    }
}

using AutoMapper;
using Domain.Models;
using TestProducts2.Dtos.Create;
using TestProducts2.Dtos.Read;
using TestProducts2.Dtos.Resolvers;
using TestProducts2.Dtos.Update;


namespace TestProducts2.Dtos.Profiles
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

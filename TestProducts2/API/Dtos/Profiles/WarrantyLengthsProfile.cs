using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Resolvers;
using API.Dtos.Update;
using AutoMapper;
using Domain.Models;


namespace API.Dtos.Profiles
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

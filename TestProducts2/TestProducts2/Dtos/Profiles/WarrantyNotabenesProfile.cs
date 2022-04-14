using AutoMapper;
using Domain.Models;
using TestProducts2.Dtos.Create;
using TestProducts2.Dtos.Read;
using TestProducts2.Dtos.Resolvers;
using TestProducts2.Dtos.Update;


namespace TestProducts2.Dtos.Profiles
{
    public class WarrantyNotabenesProfile : Profile
    {
        public WarrantyNotabenesProfile()
        {
            CreateMap<WarrantyNotabene, WarrantyNotabeneReadDto>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom<DescriptionResolver<WarrantyNotabeneDescription, WarrantyNotabeneDescriptionReadDto>>());
            CreateMap<WarrantyNotabeneDescription, WarrantyNotabeneDescriptionReadDto>();

            CreateMap<WarrantyNotabeneCreateDto, WarrantyNotabene>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));
            CreateMap<WarrantyNotabeneDescriptionCreateDto, WarrantyNotabeneDescription>();

            CreateMap<WarrantyNotabeneUpdateDto, WarrantyNotabene>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));

            CreateMap<WarrantyNotabeneDescriptionUpdateDto, WarrantyNotabeneDescription>();
        }
    }
}

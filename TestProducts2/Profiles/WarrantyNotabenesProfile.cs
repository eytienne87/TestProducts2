using AutoMapper;
using TestProducts2.Domain.Models;
using TestProducts2.Dtos.Read;
using TestProducts2.Dtos.Update;
using TestProducts2.Entities;


namespace TestProducts2.Profiles
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

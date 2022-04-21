using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Resolvers;
using API.Dtos.Update;
using AutoMapper;
using Domain.Models;


namespace API.Dtos.Profiles
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

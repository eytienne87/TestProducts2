using AutoMapper;
using TestProducts2.Dtos;
using TestProducts2.Entities;
using TestProducts2.Models;

namespace TestProducts2.Profiles
{
    public class WarrantiesProfile : Profile
    {
        public WarrantiesProfile()
        {
            CreateMap<Warranty, WarrantyReadDto>()
                .ForMember(dest => dest.WarrantyTitle, opt => opt.MapFrom(src => src.WarrantyTitle))
                .ForMember(dest => dest.WarrantyLength, opt => opt.MapFrom(src => src.WarrantyLength))
                .ForMember(dest => dest.WarrantyNotabene, opt => opt.MapFrom(src => src.WarrantyNotabene));

            CreateMap<WarrantyCreateDto, Warranty>()
                .ForMember(dest => dest.WarrantyTitle, opt => opt.MapFrom(src => new WarrantyTitle { Id = src.WarrantyTitleId }))
                .ForMember(dest => dest.WarrantyLength, opt => opt.MapFrom(src => new WarrantyLength { Id = src.WarrantyLengthId }))
                .ForMember(dest => dest.WarrantyNotabene, opt => opt.MapFrom(src => new WarrantyNotabene { Id = src.WarrantyNotabeneId }));

            CreateMap<Warranty, WarrantyUpdateDto>()
                .ForMember(dest => dest.WarrantyTitleId, opt => opt.MapFrom(src => src.WarrantyTitle.Id))
                .ForMember(dest => dest.WarrantyLengthId, opt => opt.MapFrom(src => src.WarrantyLength.Id))
                .ForMember(dest => dest.WarrantyNotabeneId, opt => opt.MapFrom(src => src.WarrantyNotabene.Id));

            CreateMap<WarrantyUpdateDto, Warranty>()
                .ForMember(dest => dest.WarrantyTitle, opt => opt.MapFrom(src => new WarrantyTitle { Id = src.WarrantyTitleId }))
                .ForMember(dest => dest.WarrantyLength, opt => opt.MapFrom(src => new WarrantyLength { Id = src.WarrantyLengthId }))
                .ForMember(dest => dest.WarrantyNotabene, opt => opt.MapFrom(src => new WarrantyNotabene { Id = src.WarrantyNotabeneId }));
        }
    }
}

using AutoMapper;
using Domain.Models;
using TestProducts2.Dtos.Create;
using TestProducts2.Dtos.Read;
using TestProducts2.Dtos.Update;


namespace TestProducts2.Dtos.Profiles
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
                .ForMember(dest => dest.WarrantyNotabeneId, opt => opt.MapFrom(src => src.WarrantyNotabene != null ? src.WarrantyNotabene.Id : 0));

            CreateMap<WarrantyUpdateDto, Warranty>()
                .ForMember(dest => dest.WarrantyTitle, opt => opt.MapFrom(src => new WarrantyTitle { Id = src.WarrantyTitleId }))
                .ForMember(dest => dest.WarrantyLength, opt => opt.MapFrom(src => new WarrantyLength { Id = src.WarrantyLengthId }))
                .ForMember(dest => dest.WarrantyNotabene, opt => opt.MapFrom(src => new WarrantyNotabene { Id = src.WarrantyNotabeneId }));
        }
    }
}

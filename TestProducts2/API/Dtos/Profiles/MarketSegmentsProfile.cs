using AutoMapper;
using Domain.Models;
using TestProducts2.Dtos.Create;
using TestProducts2.Dtos.Read;
using TestProducts2.Dtos.Resolvers;
using TestProducts2.Dtos.Update;


namespace TestProducts2.Dtos.Profiles
{
    public class MarketSegmentsProfile : Profile
    {
        public MarketSegmentsProfile()
        {
            CreateMap<MarketSegment, MarketSegmentReadDto>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom<DescriptionResolver<MarketSegmentDescription, MarketSegmentDescriptionReadDto>>());

            CreateMap<MarketSegmentDescription, MarketSegmentDescriptionReadDto>();

            CreateMap<MarketSegmentCreateDto, MarketSegment>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));
            CreateMap<MarketSegmentDescriptionCreateDto, MarketSegmentDescription>();

            CreateMap<MarketSegmentUpdateDto, MarketSegment>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));
            CreateMap<MarketSegmentDescriptionUpdateDto, MarketSegmentDescription>();

            CreateMap<MarketSegment, MarketSegmentUpdateDto>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));

            CreateMap<MarketSegmentDescription, MarketSegmentDescriptionUpdateDto>();
        }
    }
}

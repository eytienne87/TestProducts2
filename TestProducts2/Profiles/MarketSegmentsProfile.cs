﻿using AutoMapper;
using TestProducts2.Dtos;
using TestProducts2.Entities;
using TestProducts2.Models;

namespace TestProducts2.Profiles
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

            CreateMap<MarketSegment, MarketSegmentUpdateDto>()
                .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src => src.Descriptions));

            CreateMap<MarketSegmentDescriptionUpdateDto, MarketSegmentDescription>();
            CreateMap<MarketSegmentDescription, MarketSegmentDescriptionUpdateDto>();
        }
    }
}
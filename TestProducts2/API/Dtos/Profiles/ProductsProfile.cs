﻿using AutoMapper;
using Domain.Models;
using TestProducts2.Dtos.Create;
using TestProducts2.Dtos.Read;
using TestProducts2.Dtos.Update;


namespace TestProducts2.Dtos.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductReadDto>()
                .ForMember(dest => dest.Benefits, opt => opt.MapFrom(src => src.Benefits))
                .ForMember(dest => dest.Warranties, opt => opt.MapFrom(src => src.Warranties));
            CreateMap<ProductReadDto, Product>();

            CreateMap<ProductCreateDto, Product>()
                .ForMember(dest => dest.Benefits, opt => opt.MapFrom(src => src.Benefits))
                .ForMember(dest => dest.Warranties, opt => opt.MapFrom(src => src.Warranties));

            CreateMap<Product, ProductUpdateDto>()
                .ForMember(dest => dest.Benefits, opt => opt.MapFrom(src => src.Benefits))
                .ForMember(dest => dest.Warranties, opt => opt.MapFrom(src => src.Warranties));

            CreateMap<ProductUpdateDto, Product>()
                .ForMember(dest => dest.Benefits, opt => opt.MapFrom(src => src.Benefits))
                .ForMember(dest => dest.Warranties, opt => opt.MapFrom(src => src.Warranties));
        }
    }
}
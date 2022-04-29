using API.Dtos.Read;
using AutoMapper;
using Domain.Models;

namespace API.Dtos.Profiles
{
    public class ColorNamesProfile : Profile
    {
        public ColorNamesProfile()
        {
            CreateMap<ColorName, ColorNameReadDto>();
        }
    }
}

using AutoMapper;
using UrlShortenerBack.Dtos;
using UrlShortenerBack.Models;

namespace UrlShortenerBack.MappingProfiles
{
    public class UrlMapperProfile : Profile
    {
        public UrlMapperProfile()
        {
            CreateMap<CreatedUrl, Url>().ReverseMap();
        }
    }
}
using AutoMapper;
using BurakNews.Core.DTOs;
using BurakNews.Core.Entities;

namespace BurakNews.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<New, NewDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<New, NewWithCategoryDto>();
            CreateMap<Category, CategoryWithNewsDto>();
        }
    }
}

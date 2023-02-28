using Application.Dtos.Category.Request;
using Application.Dtos.Category.Response;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
    public class CategoryMappingsProfiles : Profile
    {
        public CategoryMappingsProfiles()
        {
            CreateMap<CategoryResponseDto, Category>();

            CreateMap<Category, CategoryResponseDto>()
                .ReverseMap();

            CreateMap<CategoryRequestDto, Category>();
        }
    }
}

using Application.Dtos.Category.Request;
using Application.Dtos.Category.Response;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Commons.Bases;

namespace Application.Mappers
{
    public class CategoryMappingsProfiles :Profile
    {
        public CategoryMappingsProfiles()
        {
            CreateMap<CategoryRequestDto, Category>();
            CreateMap<Category, CategoryRequestDto>()
                .ReverseMap();

            CreateMap<BaseEntityResponse<Category>, BaseEntityResponse<CategoryResponseDto>>()
                .ReverseMap();
        }
    }
}

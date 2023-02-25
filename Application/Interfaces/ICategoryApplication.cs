using Application.Base;
using Application.Dtos.Category.Request;
using Application.Dtos.Category.Response;

namespace Application.Interfaces
{
    public interface ICategoryApplication
    {
        Task<BaseResponse<IEnumerable<CategoryResponseDto>>> ListCategories();
        Task<BaseResponse<CategoryResponseDto>> GetCategoryById(int Id);
        Task<BaseResponse<bool>> RegisterCategory(CategoryRequestDto requestDto);
        Task<BaseResponse<bool>> EditCategory(CategoryRequestDto requestDto, int Id);
        Task<BaseResponse<bool>> DeleteCategory(int categoryId);
    }
}

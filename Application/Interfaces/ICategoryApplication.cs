using Application.Base;
using Application.Dtos.Category.Response;

namespace Application.Interfaces
{
    public interface ICategoryApplication
    {
        Task<BaseResponse<IEnumerable<CategoryResponseDto>>> ListCategories();
    }
}

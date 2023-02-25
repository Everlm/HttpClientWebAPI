using Application.Base;
using Application.Dtos.Category.Request;
using Application.Dtos.Category.Response;
using Application.Interfaces;

namespace Application.ApplicationServices.Category
{
    public class CategoryApplication : ICategoryApplication
    {
        public CategoryApplication()
        {
            
        }
        public Task<BaseResponse<bool>> DeleteCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> EditCategory(CategoryRequestDto requestDto, int Id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<CategoryResponseDto>> GetCategoryById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<CategoryResponseDto>>> ListCategories()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> RegisterCategory(CategoryRequestDto requestDto)
        {
            throw new NotImplementedException();
        }
    }
}

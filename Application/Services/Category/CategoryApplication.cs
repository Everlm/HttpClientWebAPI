using Application.Base;
using Application.Dtos.Category.Request;
using Application.Dtos.Category.Response;
using Application.Interfaces;
using AutoMapper;
using Infrastructure.Interfaces;
using Utilities.Static;

namespace Application.ApplicationServices.Category
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryApplication(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<CategoryResponseDto>>> ListCategories()
        {
            var response = new BaseResponse<IEnumerable<CategoryResponseDto>>();
            var categories = await _categoryRepository.GetAllAsync();

            if (categories is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<CategoryResponseDto>>(categories);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }
        public Task<BaseResponse<CategoryResponseDto>> GetCategoryById(int Id)
        {
            throw new NotImplementedException();
        }
        public Task<BaseResponse<bool>> RegisterCategory(CategoryRequestDto requestDto)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> EditCategory(CategoryRequestDto requestDto, int Id)
        {
            throw new NotImplementedException();
        }
        public Task<BaseResponse<bool>> DeleteCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

    }
}

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
                response.Message = ReplyMessage.MESSAGE_REQUEST;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_REQUEST_EMPTY;
            }

            return response;
        }
        public async Task<BaseResponse<CategoryResponseDto>> GetCategoryById(int Id)
        {
            var response = new BaseResponse<CategoryResponseDto>();
            var categories = await _categoryRepository.GetByIdAsync(Id);

            if (categories is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<CategoryResponseDto>(categories);
                response.Message = ReplyMessage.MESSAGE_REQUEST;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_REQUEST_EMPTY;
            }

            return response;
        }
        public async Task<BaseResponse<bool>> RegisterCategory(CategoryRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var category = _mapper.Map<Domain.Entities.Category>(requestDto);
            response.Data = await _categoryRepository.RegisterAsync(category);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message += ReplyMessage.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message += ReplyMessage.MESSAGE_FAILED;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> EditCategory(CategoryRequestDto requestDto, int Id)
        {
            var response = new BaseResponse<bool>();
            var categoryEdit = await GetCategoryById(Id);

            if (categoryEdit.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_REQUEST_EMPTY;
                return response;
            }

            var category = _mapper.Map<Domain.Entities.Category>(requestDto);
            category.id = Id;
            response.Data = await _categoryRepository.EditAsync(category, Id);


            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_UPDATE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;

        }
        public async Task<BaseResponse<bool>> DeleteCategory(int Id)
        {
            var response = new BaseResponse<bool>();
            var category = await GetCategoryById(Id);

            if (category.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_REQUEST_EMPTY;
            }

            response.Data = await _categoryRepository.DeleteAsync(Id);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_DELETE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;

        }

    }
}

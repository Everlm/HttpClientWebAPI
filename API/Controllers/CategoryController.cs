using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryApplication _categoryApplication;
        public CategoryController(ICategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }

        [HttpGet("AllCategories")]
        public async Task<IActionResult> ListSelectCategories()
        {
            var response = await _categoryApplication.ListCategories();
            return Ok(response);
        }
    }
}

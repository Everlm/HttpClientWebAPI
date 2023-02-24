using Domain.Entities;

namespace Infrastructure.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> RegisterAsync(Category category);
        Task<Category> EditAsync(Category category, int id);
        Task DeleteAsync(int Category);
    }
}

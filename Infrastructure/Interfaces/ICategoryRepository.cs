using Domain.Entities;

namespace Infrastructure.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<bool> RegisterAsync(Category category);
        Task<bool> EditAsync(Category category, int id);
        Task<bool> DeleteAsync(int Category);
    }
}

using Domain.Entities;
using Domain.Interfaces;
using System.Text.Json;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : IGenericRepository<Category>
    {

        private readonly HttpClient _httpClient;
        public CategoryRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("https://api.escuelajs.co/api/v1/categories");
           
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var categories = JsonSerializer.Deserialize<IEnumerable<Category>>(content,
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive=true});
                return categories!;
            }

            return null;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}

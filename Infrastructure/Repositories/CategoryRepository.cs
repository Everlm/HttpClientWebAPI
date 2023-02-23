using Domain.Entities;
using Domain.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : IGenericRepository<Category>
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public CategoryRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var client = _httpClientFactory.CreateClient("Client");
            var response = await client.GetAsync("/api/v1/categories");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<Category>>();

            //if (response.IsSuccessStatusCode)
            //{
            //    var content = await response.Content.ReadAsStringAsync();
            //    var categories = JsonSerializer.Deserialize<IEnumerable<Category>>(content,
            //        new JsonSerializerOptions() { PropertyNameCaseInsensitive=true});
            //    return categories!;
            //}

            //return null;
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

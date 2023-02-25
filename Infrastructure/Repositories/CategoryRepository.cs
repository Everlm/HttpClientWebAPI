using Domain.Entities;
using Infrastructure.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly HttpClient _httpClient;
        private readonly string baseURL = "https://api.escuelajs.co/api/v1/categories/";
        public CategoryRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(baseURL);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<Category>>(content);

            return result!;

        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{baseURL}{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Category>(content);

            return result!;
        }

        public async Task<bool> RegisterAsync(Category category)
        {
            var response = await _httpClient.PostAsJsonAsync("{baseURL}", category);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(content);

            return result;

        }

        public async Task<bool> EditAsync(Category category, int id)
        {
            var response = await _httpClient.PutAsJsonAsync($"{baseURL}{id}", category);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(content);

            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{baseURL}{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(content);

            return result;
        }
    }
}

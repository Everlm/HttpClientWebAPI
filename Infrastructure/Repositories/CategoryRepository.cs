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

            return result;

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
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(baseURL, category);          
            return response.IsSuccessStatusCode;
         
        }

        public async Task<bool> EditAsync(Category category, int id)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{baseURL}{id}", category);
            return response.IsSuccessStatusCode;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"{baseURL}{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

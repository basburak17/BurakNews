using BurakNews.Core.DTOs;

namespace BurakNews.Web.Services
{
    public class NewsApiService
    {
        private readonly HttpClient _httpClient;

        public NewsApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<NewWithCategoryDto>> GetNewsWithCategoryAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<NewWithCategoryDto>>>("news/GetNewsWithCategory");
            return response.Data;
        }
        public async Task<NewDto> SaveAsync(NewDto newDto)
        {
            var response = await _httpClient.PostAsJsonAsync("news",newDto);
            if(response.IsSuccessStatusCode) { return null; }
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<NewDto>>();
            return responseBody.Data;
        }
        public async Task<bool> UpdateAsync(NewDto newDto)
        {
            var response = await _httpClient.PutAsJsonAsync("news", newDto);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"news/{id}");
            return response.IsSuccessStatusCode;
        }
        public async Task<NewDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<NewDto>>($"news/{id}");
            return response.Data;
        }
    }
}

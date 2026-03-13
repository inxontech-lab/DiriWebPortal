using System.Net.Http.Json;
using Domain.DBModels;
using Domain.RespDTO.MasterSchemaRespDTO;

namespace DiriWebAdmin.Services
{
    public class UsersApiClient
    {
        private readonly HttpClient _httpClient;

        public UsersApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<UserRespDTO>("api/Users");
            return response?.lstData ?? new List<User>();
        }

        public async Task<UserRespDTO?> CreateAsync(User user)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Users", user);
            return await response.Content.ReadFromJsonAsync<UserRespDTO>();
        }

        public async Task<UserRespDTO?> UpdateAsync(User user)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Users/{user.UserId}", user);
            return await response.Content.ReadFromJsonAsync<UserRespDTO>();
        }

        public async Task<UserRespDTO?> DeleteAsync(int userId)
        {
            var response = await _httpClient.DeleteAsync($"api/Users/{userId}");
            return await response.Content.ReadFromJsonAsync<UserRespDTO>();
        }
    }
}

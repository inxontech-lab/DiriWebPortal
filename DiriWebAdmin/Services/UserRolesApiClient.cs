using System.Net.Http.Json;
using Domain.DBModels;
using Domain.RespDTO.MasterSchemaRespDTO;

namespace DiriWebAdmin.Services
{
    public class UserRolesApiClient
    {
        private readonly HttpClient _httpClient;

        public UserRolesApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UserRole>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<UserRoleRespDTO>("api/UserRoles");
            return response?.lstData ?? new List<UserRole>();
        }

        public async Task<UserRoleRespDTO?> CreateAsync(UserRole userRole)
        {
            var response = await _httpClient.PostAsJsonAsync("api/UserRoles", userRole);
            return await response.Content.ReadFromJsonAsync<UserRoleRespDTO>();
        }

        public async Task<UserRoleRespDTO?> UpdateAsync(UserRole userRole)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/UserRoles/{userRole.UserRoleId}", userRole);
            return await response.Content.ReadFromJsonAsync<UserRoleRespDTO>();
        }

        public async Task<UserRoleRespDTO?> DeleteAsync(int userRoleId)
        {
            var response = await _httpClient.DeleteAsync($"api/UserRoles/{userRoleId}");
            return await response.Content.ReadFromJsonAsync<UserRoleRespDTO>();
        }
    }
}

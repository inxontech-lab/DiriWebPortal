using System.Net.Http.Json;
using Domain.DBModels;
using Domain.RespDTO.MasterSchemaRespDTO;

namespace DiriWebAdmin.Services
{
    public class RoleMasterApiClient
    {
        private readonly HttpClient _httpClient;

        public RoleMasterApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<RoleMaster>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<RoleMasterRespDTO>("api/RoleMaster");
            return response?.lstData ?? new List<RoleMaster>();
        }

        public async Task<RoleMasterRespDTO?> CreateAsync(RoleMaster roleMaster)
        {
            var response = await _httpClient.PostAsJsonAsync("api/RoleMaster", roleMaster);
            return await response.Content.ReadFromJsonAsync<RoleMasterRespDTO>();
        }

        public async Task<RoleMasterRespDTO?> UpdateAsync(RoleMaster roleMaster)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/RoleMaster/{roleMaster.RoleId}", roleMaster);
            return await response.Content.ReadFromJsonAsync<RoleMasterRespDTO>();
        }

        public async Task<RoleMasterRespDTO?> DeleteAsync(int roleId)
        {
            var response = await _httpClient.DeleteAsync($"api/RoleMaster/{roleId}");
            return await response.Content.ReadFromJsonAsync<RoleMasterRespDTO>();
        }
    }
}

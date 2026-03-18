using System.Net;
using System.Net.Http.Json;
using Domain.DTO.Auth;
using Domain.RespDTO.Auth;

namespace Shared.AdminClientService.Auth;

public class AdminAuthApiClient
{
    private readonly HttpClient _httpClient;

    public AdminAuthApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<AdminLoginRespDTO> LoginAsync(AdminLoginRequestDTO request)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync("api/AdminAuth/login", request);

        if (httpResponse.IsSuccessStatusCode)
        {
            return await httpResponse.Content.ReadFromJsonAsync<AdminLoginRespDTO>() ?? new AdminLoginRespDTO
            {
                RESPONSE_CODE = ((int)HttpStatusCode.InternalServerError).ToString(),
                RESPONSE_DESCRPTION = "Empty login response received from server."
            };
        }

        return await httpResponse.Content.ReadFromJsonAsync<AdminLoginRespDTO>() ?? new AdminLoginRespDTO
        {
            RESPONSE_CODE = ((int)httpResponse.StatusCode).ToString(),
            RESPONSE_DESCRPTION = "Login failed."
        };
    }
}

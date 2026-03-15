using System.Net.Http.Json;

namespace DiriWebAdmin.Data;

public class RoleMasterApiClient
{
    private readonly HttpClient _httpClient;

    public RoleMasterApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<RoleMasterDto>> GetAllAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<RoleMasterResponseDto>("api/RoleMaster");
        return response?.lstData ?? new List<RoleMasterDto>();
    }

    public async Task<RoleMasterDto?> CreateAsync(RoleMasterDto request)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync("api/RoleMaster", request);
        httpResponse.EnsureSuccessStatusCode();

        var response = await httpResponse.Content.ReadFromJsonAsync<RoleMasterResponseDto>();
        return response?.data;
    }

    public async Task<RoleMasterDto?> UpdateAsync(RoleMasterDto request)
    {
        var httpResponse = await _httpClient.PutAsJsonAsync($"api/RoleMaster/{request.RoleId}", request);
        httpResponse.EnsureSuccessStatusCode();

        var response = await httpResponse.Content.ReadFromJsonAsync<RoleMasterResponseDto>();
        return response?.data;
    }

    public async Task DeleteAsync(int roleId)
    {
        var httpResponse = await _httpClient.DeleteAsync($"api/RoleMaster/{roleId}");
        httpResponse.EnsureSuccessStatusCode();
    }
}

public class RoleMasterDto
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = string.Empty;
    public string? RoleCode { get; set; }
    public string? Description { get; set; }
    public bool? IsActive { get; set; } = true;
    public DateTime? CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? ModifiedBy { get; set; }
}

public class RoleMasterResponseDto
{
    public string RESPONSE_CODE { get; set; } = string.Empty;
    public string RESPONSE_DESCRPTION { get; set; } = string.Empty;
    public RoleMasterDto? data { get; set; }
    public List<RoleMasterDto>? lstData { get; set; }
}

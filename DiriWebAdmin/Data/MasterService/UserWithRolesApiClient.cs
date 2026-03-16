using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;

namespace DiriWebAdmin.Data.MasterService;

public class UserWithRolesApiClient
{
    private readonly HttpClient _httpClient;

    public UserWithRolesApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<UserWithRolesDto>> GetAllAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<UserWithRolesResponseDto>("api/UserWithRoles");
        return response?.lstData ?? new List<UserWithRolesDto>();
    }

    public async Task<UserWithRolesDto?> CreateAsync(UserWithRolesDto request)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync("api/UserWithRoles", request);
        httpResponse.EnsureSuccessStatusCode();
        var response = await httpResponse.Content.ReadFromJsonAsync<UserWithRolesResponseDto>();
        return response?.data;
    }

    public async Task<UserWithRolesDto?> UpdateAsync(UserWithRolesDto request)
    {
        var httpResponse = await _httpClient.PutAsJsonAsync($"api/UserWithRoles/{request.UserId}", request);
        httpResponse.EnsureSuccessStatusCode();
        var response = await httpResponse.Content.ReadFromJsonAsync<UserWithRolesResponseDto>();
        return response?.data;
    }

    public async Task DeleteAsync(int userId)
    {
        var httpResponse = await _httpClient.DeleteAsync($"api/UserWithRoles/{userId}");
        httpResponse.EnsureSuccessStatusCode();
    }

    public async Task<List<RoleMasterDto>> GetRolesAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<RoleMasterResponseDto>("api/RoleMaster");
        return response?.lstData ?? new List<RoleMasterDto>();
    }
}

public class UserWithRolesDto
{
    public int UserId { get; set; }

    [Required(ErrorMessage = "User Name is required.")]
    public string UserName { get; set; } = string.Empty;


    [EmailAddress(ErrorMessage = "Email is not valid.")]
    public string? Email { get; set; }

    public string? MobileNo { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    public string PasswordHash { get; set; } = string.Empty;

    public bool? IsActive { get; set; } = true;
    public bool? IsLocked { get; set; } = false;
    public DateTime? LastLoginDate { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? ModifiedBy { get; set; }

    [MinLength(1, ErrorMessage = "At least one role is required.")]
    public List<int> RoleIds { get; set; } = new();
}

public class UserWithRolesResponseDto
{
    public string RESPONSE_CODE { get; set; } = string.Empty;
    public string RESPONSE_DESCRPTION { get; set; } = string.Empty;
    public UserWithRolesDto? data { get; set; }
    public List<UserWithRolesDto>? lstData { get; set; }
}

using System.Net.Http.Json;
using Domain.DBModels;
using Domain.RespDTO.HomepageRespDTO;

namespace Shared.AdminClientService.HomePage;

public class HomePageApiClient
{
    private readonly HttpClient _httpClient;

    public HomePageApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<BannerText>> GetBannerTextsAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<BannerTextCrudRespDTO>("api/HomePageSchema/bannertexts");
        return response?.lstData ?? new List<BannerText>();
    }

    public async Task<BannerText?> CreateBannerTextAsync(BannerText request)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync("api/HomePageSchema/bannertexts", request);
        httpResponse.EnsureSuccessStatusCode();
        var response = await httpResponse.Content.ReadFromJsonAsync<BannerTextCrudRespDTO>();
        return response?.data;
    }

    public async Task<BannerText?> UpdateBannerTextAsync(BannerText request)
    {
        var httpResponse = await _httpClient.PutAsJsonAsync($"api/HomePageSchema/bannertexts/{request.Id}", request);
        httpResponse.EnsureSuccessStatusCode();
        var response = await httpResponse.Content.ReadFromJsonAsync<BannerTextCrudRespDTO>();
        return response?.data;
    }

    public async Task DeleteBannerTextAsync(int id)
    {
        var httpResponse = await _httpClient.DeleteAsync($"api/HomePageSchema/bannertexts/{id}");
        httpResponse.EnsureSuccessStatusCode();
    }

    public async Task<List<NumericDashboard>> GetNumericDashboardsAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<NumericDashboardCrudRespDTO>("api/HomePageSchema/numericdashboards");
        return response?.lstData ?? new List<NumericDashboard>();
    }

    public async Task<NumericDashboard?> CreateNumericDashboardAsync(NumericDashboard request)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync("api/HomePageSchema/numericdashboards", request);
        httpResponse.EnsureSuccessStatusCode();
        var response = await httpResponse.Content.ReadFromJsonAsync<NumericDashboardCrudRespDTO>();
        return response?.data;
    }

    public async Task<NumericDashboard?> UpdateNumericDashboardAsync(NumericDashboard request)
    {
        var httpResponse = await _httpClient.PutAsJsonAsync($"api/HomePageSchema/numericdashboards/{request.Id}", request);
        httpResponse.EnsureSuccessStatusCode();
        var response = await httpResponse.Content.ReadFromJsonAsync<NumericDashboardCrudRespDTO>();
        return response?.data;
    }

    public async Task DeleteNumericDashboardAsync(int id)
    {
        var httpResponse = await _httpClient.DeleteAsync($"api/HomePageSchema/numericdashboards/{id}");
        httpResponse.EnsureSuccessStatusCode();
    }

    public async Task<List<AboutU>> GetAboutUsAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<AboutUsCrudRespDTO>("api/HomePageSchema/aboutus");
        return response?.lstData ?? new List<AboutU>();
    }

    public async Task<AboutU?> CreateAboutUsAsync(AboutU request)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync("api/HomePageSchema/aboutus", request);
        httpResponse.EnsureSuccessStatusCode();
        var response = await httpResponse.Content.ReadFromJsonAsync<AboutUsCrudRespDTO>();
        return response?.data;
    }

    public async Task<AboutU?> UpdateAboutUsAsync(AboutU request)
    {
        var httpResponse = await _httpClient.PutAsJsonAsync($"api/HomePageSchema/aboutus/{request.Id}", request);
        httpResponse.EnsureSuccessStatusCode();
        var response = await httpResponse.Content.ReadFromJsonAsync<AboutUsCrudRespDTO>();
        return response?.data;
    }

    public async Task DeleteAboutUsAsync(int id)
    {
        var httpResponse = await _httpClient.DeleteAsync($"api/HomePageSchema/aboutus/{id}");
        httpResponse.EnsureSuccessStatusCode();
    }

    public async Task<List<FounderInfo>> GetFounderInfosAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<FounderInfoCrudRespDTO>("api/HomePageSchema/founderinfo");
        return response?.lstData ?? new List<FounderInfo>();
    }

    public async Task<FounderInfo?> CreateFounderInfoAsync(FounderInfo request)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync("api/HomePageSchema/founderinfo", request);
        httpResponse.EnsureSuccessStatusCode();
        var response = await httpResponse.Content.ReadFromJsonAsync<FounderInfoCrudRespDTO>();
        return response?.data;
    }

    public async Task<FounderInfo?> UpdateFounderInfoAsync(FounderInfo request)
    {
        var httpResponse = await _httpClient.PutAsJsonAsync($"api/HomePageSchema/founderinfo/{request.Id}", request);
        httpResponse.EnsureSuccessStatusCode();
        var response = await httpResponse.Content.ReadFromJsonAsync<FounderInfoCrudRespDTO>();
        return response?.data;
    }

    public async Task DeleteFounderInfoAsync(int id)
    {
        var httpResponse = await _httpClient.DeleteAsync($"api/HomePageSchema/founderinfo/{id}");
        httpResponse.EnsureSuccessStatusCode();
    }

    public async Task<List<ManagingTrusteeInfo>> GetManagingTrusteeInfosAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ManagingTrusteeInfoCrudRespDTO>("api/HomePageSchema/managingtrusteeinfo");
        return response?.lstData ?? new List<ManagingTrusteeInfo>();
    }

    public async Task<ManagingTrusteeInfo?> CreateManagingTrusteeInfoAsync(ManagingTrusteeInfo request)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync("api/HomePageSchema/managingtrusteeinfo", request);
        httpResponse.EnsureSuccessStatusCode();
        var response = await httpResponse.Content.ReadFromJsonAsync<ManagingTrusteeInfoCrudRespDTO>();
        return response?.data;
    }

    public async Task<ManagingTrusteeInfo?> UpdateManagingTrusteeInfoAsync(ManagingTrusteeInfo request)
    {
        var httpResponse = await _httpClient.PutAsJsonAsync($"api/HomePageSchema/managingtrusteeinfo/{request.Id}", request);
        httpResponse.EnsureSuccessStatusCode();
        var response = await httpResponse.Content.ReadFromJsonAsync<ManagingTrusteeInfoCrudRespDTO>();
        return response?.data;
    }

    public async Task DeleteManagingTrusteeInfoAsync(int id)
    {
        var httpResponse = await _httpClient.DeleteAsync($"api/HomePageSchema/managingtrusteeinfo/{id}");
        httpResponse.EnsureSuccessStatusCode();
    }
}

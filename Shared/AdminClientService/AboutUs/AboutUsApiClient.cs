using System.Net.Http.Json;
using Domain.DBModels;
using Domain.RespDTO.AboutUsPageRespDTO;
using Domain.RespDTO.HomepageRespDTO;

namespace Shared.AdminClientService.AboutUs;

public class AboutUsApiClient
{
    private readonly HttpClient _httpClient;

    public AboutUsApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<AboutUsDetail>> GetAboutUsDetailsAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<AboutUsDetailsCrudRespDTO>("api/AboutUsSchema/details");
        return response?.lstData ?? new List<AboutUsDetail>();
    }

    public async Task<AboutUsDetail?> CreateAboutUsDetailAsync(AboutUsDetail request)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync("api/AboutUsSchema/details", request);
        httpResponse.EnsureSuccessStatusCode();
        var response = await httpResponse.Content.ReadFromJsonAsync<AboutUsDetailsCrudRespDTO>();
        return response?.data;
    }

    public async Task<AboutUsDetail?> UpdateAboutUsDetailAsync(AboutUsDetail request)
    {
        var httpResponse = await _httpClient.PutAsJsonAsync($"api/AboutUsSchema/details/{request.Id}", request);
        httpResponse.EnsureSuccessStatusCode();
        var response = await httpResponse.Content.ReadFromJsonAsync<AboutUsDetailsCrudRespDTO>();
        return response?.data;
    }

    public async Task DeleteAboutUsDetailAsync(int id)
    {
        var httpResponse = await _httpClient.DeleteAsync($"api/AboutUsSchema/details/{id}");
        httpResponse.EnsureSuccessStatusCode();
    }

    public async Task<List<FounderInfo>> GetFounderInfosAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<FounderInfoCrudRespDTO>("api/AboutUsSchema/founderinfo");
        return response?.lstData ?? new List<FounderInfo>();
    }

    public async Task<FounderInfo?> CreateFounderInfoAsync(FounderInfo request)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync("api/AboutUsSchema/founderinfo", request);
        httpResponse.EnsureSuccessStatusCode();
        var response = await httpResponse.Content.ReadFromJsonAsync<FounderInfoCrudRespDTO>();
        return response?.data;
    }

    public async Task<FounderInfo?> UpdateFounderInfoAsync(FounderInfo request)
    {
        var httpResponse = await _httpClient.PutAsJsonAsync($"api/AboutUsSchema/founderinfo/{request.Id}", request);
        httpResponse.EnsureSuccessStatusCode();
        var response = await httpResponse.Content.ReadFromJsonAsync<FounderInfoCrudRespDTO>();
        return response?.data;
    }

    public async Task DeleteFounderInfoAsync(int id)
    {
        var httpResponse = await _httpClient.DeleteAsync($"api/AboutUsSchema/founderinfo/{id}");
        httpResponse.EnsureSuccessStatusCode();
    }

    public async Task<List<ManagingTrusteeInfo>> GetManagingTrusteeInfosAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ManagingTrusteeInfoCrudRespDTO>("api/AboutUsSchema/managingtrusteeinfo");
        return response?.lstData ?? new List<ManagingTrusteeInfo>();
    }

    public async Task<ManagingTrusteeInfo?> CreateManagingTrusteeInfoAsync(ManagingTrusteeInfo request)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync("api/AboutUsSchema/managingtrusteeinfo", request);
        httpResponse.EnsureSuccessStatusCode();
        var response = await httpResponse.Content.ReadFromJsonAsync<ManagingTrusteeInfoCrudRespDTO>();
        return response?.data;
    }

    public async Task<ManagingTrusteeInfo?> UpdateManagingTrusteeInfoAsync(ManagingTrusteeInfo request)
    {
        var httpResponse = await _httpClient.PutAsJsonAsync($"api/AboutUsSchema/managingtrusteeinfo/{request.Id}", request);
        httpResponse.EnsureSuccessStatusCode();
        var response = await httpResponse.Content.ReadFromJsonAsync<ManagingTrusteeInfoCrudRespDTO>();
        return response?.data;
    }

    public async Task DeleteManagingTrusteeInfoAsync(int id)
    {
        var httpResponse = await _httpClient.DeleteAsync($"api/AboutUsSchema/managingtrusteeinfo/{id}");
        httpResponse.EnsureSuccessStatusCode();
    }

    public async Task<List<ManagingTrusteeDesignation>> GetManagingTrusteeDesignationsAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ManagingTrusteeDesignationCrudRespDTO>("api/AboutUsSchema/designations");
        return response?.lstData ?? new List<ManagingTrusteeDesignation>();
    }

    public async Task<ManagingTrusteeDesignation?> CreateManagingTrusteeDesignationAsync(ManagingTrusteeDesignation request)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync("api/AboutUsSchema/designations", request);
        httpResponse.EnsureSuccessStatusCode();
        var response = await httpResponse.Content.ReadFromJsonAsync<ManagingTrusteeDesignationCrudRespDTO>();
        return response?.data;
    }

    public async Task<ManagingTrusteeDesignation?> UpdateManagingTrusteeDesignationAsync(ManagingTrusteeDesignation request)
    {
        var httpResponse = await _httpClient.PutAsJsonAsync($"api/AboutUsSchema/designations/{request.Id}", request);
        httpResponse.EnsureSuccessStatusCode();
        var response = await httpResponse.Content.ReadFromJsonAsync<ManagingTrusteeDesignationCrudRespDTO>();
        return response?.data;
    }

    public async Task DeleteManagingTrusteeDesignationAsync(int id)
    {
        var httpResponse = await _httpClient.DeleteAsync($"api/AboutUsSchema/designations/{id}");
        httpResponse.EnsureSuccessStatusCode();
    }

    public async Task<List<ManagingTrusteeArticle>> GetManagingTrusteeArticlesAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ManagingTrusteeArticleCrudRespDTO>("api/AboutUsSchema/articles");
        return response?.lstData ?? new List<ManagingTrusteeArticle>();
    }

    public async Task<ManagingTrusteeArticle?> CreateManagingTrusteeArticleAsync(ManagingTrusteeArticle request)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync("api/AboutUsSchema/articles", request);
        httpResponse.EnsureSuccessStatusCode();
        var response = await httpResponse.Content.ReadFromJsonAsync<ManagingTrusteeArticleCrudRespDTO>();
        return response?.data;
    }

    public async Task<ManagingTrusteeArticle?> UpdateManagingTrusteeArticleAsync(ManagingTrusteeArticle request)
    {
        var httpResponse = await _httpClient.PutAsJsonAsync($"api/AboutUsSchema/articles/{request.Id}", request);
        httpResponse.EnsureSuccessStatusCode();
        var response = await httpResponse.Content.ReadFromJsonAsync<ManagingTrusteeArticleCrudRespDTO>();
        return response?.data;
    }

    public async Task DeleteManagingTrusteeArticleAsync(int id)
    {
        var httpResponse = await _httpClient.DeleteAsync($"api/AboutUsSchema/articles/{id}");
        httpResponse.EnsureSuccessStatusCode();
    }

    public async Task<List<ManagingTrusteePublication>> GetManagingTrusteePublicationsAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ManagingTrusteePublicationCrudRespDTO>("api/AboutUsSchema/publications");
        return response?.lstData ?? new List<ManagingTrusteePublication>();
    }

    public async Task<ManagingTrusteePublication?> CreateManagingTrusteePublicationAsync(ManagingTrusteePublication request)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync("api/AboutUsSchema/publications", request);
        httpResponse.EnsureSuccessStatusCode();
        var response = await httpResponse.Content.ReadFromJsonAsync<ManagingTrusteePublicationCrudRespDTO>();
        return response?.data;
    }

    public async Task<ManagingTrusteePublication?> UpdateManagingTrusteePublicationAsync(ManagingTrusteePublication request)
    {
        var httpResponse = await _httpClient.PutAsJsonAsync($"api/AboutUsSchema/publications/{request.Id}", request);
        httpResponse.EnsureSuccessStatusCode();
        var response = await httpResponse.Content.ReadFromJsonAsync<ManagingTrusteePublicationCrudRespDTO>();
        return response?.data;
    }

    public async Task DeleteManagingTrusteePublicationAsync(int id)
    {
        var httpResponse = await _httpClient.DeleteAsync($"api/AboutUsSchema/publications/{id}");
        httpResponse.EnsureSuccessStatusCode();
    }
}

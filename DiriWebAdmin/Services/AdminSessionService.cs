using System.Text.Json;
using Domain.DTO.Auth;
using Microsoft.JSInterop;

namespace DiriWebAdmin.Services;

public class AdminSessionService
{
    private const string SessionStorageKey = "diri-admin-session";
    private readonly IJSRuntime _jsRuntime;

    public AdminSessionService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<AdminSessionDTO?> GetSessionAsync()
    {
        try
        {
            var json = await _jsRuntime.InvokeAsync<string?>("adminSession.get", SessionStorageKey);
            return string.IsNullOrWhiteSpace(json)
                ? null
                : JsonSerializer.Deserialize<AdminSessionDTO>(json);
        }
        catch (JSException)
        {
            return null;
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }

    public async Task<bool> IsAuthenticatedAsync()
    {
        return (await GetSessionAsync()) is not null;
    }

    public async Task SetSessionAsync(AdminSessionDTO session)
    {
        var json = JsonSerializer.Serialize(session);
        await _jsRuntime.InvokeVoidAsync("adminSession.set", SessionStorageKey, json);
    }

    public async Task ClearSessionAsync()
    {
        await _jsRuntime.InvokeVoidAsync("adminSession.remove", SessionStorageKey);
    }
}

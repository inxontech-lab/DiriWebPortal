using DiriWebAdmin.Services;
using Domain.DTO.Auth;
using Microsoft.AspNetCore.Components;
using Radzen;
using Shared.AdminClientService.Auth;

namespace DiriWebAdmin.Components.Pages.CommonForms;

public partial class Login : ComponentBase
{
    [Inject] private AdminAuthApiClient AdminAuthApiClient { get; set; } = default!;
    [Inject] private AdminSessionService AdminSessionService { get; set; } = default!;
    [Inject] private NavigationManager NavigationManager { get; set; } = default!;
    [Inject] private NotificationService NotificationService { get; set; } = default!;

    private readonly AdminLoginRequestDTO loginRequest = new();
    private string? errorMessage;
    private bool isSubmitting;
    private bool hasCheckedSession;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender || hasCheckedSession)
        {
            return;
        }

        hasCheckedSession = true;
        if (await AdminSessionService.IsAuthenticatedAsync())
        {
            NavigationManager.NavigateTo("/", forceLoad: true);
        }
    }

    private async Task HandleLoginAsync()
    {
        errorMessage = null;
        isSubmitting = true;

        try
        {
            var response = await AdminAuthApiClient.LoginAsync(loginRequest);
            if (response.data is null)
            {
                errorMessage = string.IsNullOrWhiteSpace(response.RESPONSE_DESCRPTION)
                    ? "Login failed. Please verify your credentials."
                    : response.RESPONSE_DESCRPTION;
                return;
            }

            await AdminSessionService.SetSessionAsync(response.data);
            NotificationService.Notify(new NotificationMessage
            {
                Severity = NotificationSeverity.Success,
                Summary = "Login successful",
                Detail = $"Welcome back, {response.data.UserName}.",
                Duration = 2500
            });

            NavigationManager.NavigateTo("/", forceLoad: true);
        }
        catch (Exception ex)
        {
            errorMessage = $"Unable to complete login. {ex.Message}";
        }
        finally
        {
            isSubmitting = false;
        }
    }
}

using Shared.AdminClientService.MasterService;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace DiriWebAdmin.Components.Pages.MasterForms;

public partial class RoleMaster : ComponentBase
{
    [Inject] private RoleMasterApiClient RoleMasterApiClient { get; set; } = default!;
    [Inject] private DialogService DialogService { get; set; } = default!;
    [Inject] private NotificationService NotificationService { get; set; } = default!;

    private List<RoleMasterDto> roles = new();
    private RoleMasterDto roleForm = new() { IsActive = true };
    private bool isEditMode;

    private bool isActiveValue
    {
        get => roleForm.IsActive ?? false;
        set => roleForm.IsActive = value;
    }

    protected override async Task OnInitializedAsync()
    {
        await LoadRolesAsync();
    }

    private async Task LoadRolesAsync()
    {
        roles = await RoleMasterApiClient.GetAllAsync();
    }

    private void EditRole(RoleMasterDto role)
    {
        roleForm = new RoleMasterDto
        {
            RoleId = role.RoleId,
            RoleName = role.RoleName,
            RoleCode = role.RoleCode,
            Description = role.Description,
            IsActive = role.IsActive,
            CreatedBy = role.CreatedBy,
            CreatedDate = role.CreatedDate,
            ModifiedBy = role.ModifiedBy,
            ModifiedDate = role.ModifiedDate
        };

        isEditMode = true;
    }

    private async Task SaveRoleAsync()
    {
        var confirmed = await DialogService.Confirm(
            isEditMode ? "Do you want to update this role?" : "Do you want to save this role?",
            "Confirmation",
            new ConfirmOptions { OkButtonText = "Yes", CancelButtonText = "No" });

        if (confirmed != true)
        {
            return;
        }

        try
        {
            if (isEditMode)
            {
                roleForm.ModifiedDate = DateTime.Now;
                await RoleMasterApiClient.UpdateAsync(roleForm);
                Notify(NotificationSeverity.Success, "Success", "Role updated successfully.");
            }
            else
            {
                roleForm.CreatedDate = DateTime.Now;
                await RoleMasterApiClient.CreateAsync(roleForm);
                Notify(NotificationSeverity.Success, "Success", "Role created successfully.");
            }

            await LoadRolesAsync();
            ResetForm();
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to save role. {ex.Message}");
        }
    }

    private async Task DeleteRoleAsync(RoleMasterDto role)
    {
        var confirmed = await DialogService.Confirm(
            $"Delete role '{role.RoleName}'?",
            "Confirmation",
            new ConfirmOptions { OkButtonText = "Yes", CancelButtonText = "No" });

        if (confirmed != true)
        {
            return;
        }

        try
        {
            await RoleMasterApiClient.DeleteAsync(role.RoleId);
            Notify(NotificationSeverity.Success, "Success", "Role deleted successfully.");

            await LoadRolesAsync();
            if (isEditMode && roleForm.RoleId == role.RoleId)
            {
                ResetForm();
            }
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to delete role. {ex.Message}");
        }
    }

    private void ResetForm()
    {
        roleForm = new RoleMasterDto { IsActive = true };
        isEditMode = false;
    }

    private void Notify(NotificationSeverity severity, string summary, string detail)
    {
        NotificationService.Notify(new NotificationMessage
        {
            Severity = severity,
            Summary = summary,
            Detail = detail,
            Duration = 4000
        });
    }
}

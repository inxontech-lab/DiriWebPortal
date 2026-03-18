using Shared.AdminClientService.MasterService;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace DiriWebAdmin.Components.Pages.MasterForms;

public partial class UserMaster : ComponentBase
{
    [Inject] private UserWithRolesApiClient UserWithRolesApiClient { get; set; } = default!;
    [Inject] private DialogService DialogService { get; set; } = default!;
    [Inject] private NotificationService NotificationService { get; set; } = default!;

    private List<UserWithRolesDto> users = new();
    private List<RoleMasterDto> availableRoles = new();
    private UserWithRolesDto userForm = new();
    private bool isEditMode;

    private IEnumerable<int> selectedRoleIds
    {
        get => userForm.RoleIds;
        set => userForm.RoleIds = value?.ToList() ?? new List<int>();
    }

    private bool isActiveValue
    {
        get => userForm.IsActive ?? false;
        set => userForm.IsActive = value;
    }

    private bool isLockedValue
    {
        get => userForm.IsLocked ?? false;
        set => userForm.IsLocked = value;
    }

    protected override async Task OnInitializedAsync()
    {
        await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        availableRoles = await UserWithRolesApiClient.GetRolesAsync();
        users = await UserWithRolesApiClient.GetAllAsync();
    }

    private void EditUser(UserWithRolesDto user)
    {
        userForm = new UserWithRolesDto
        {
            UserId = user.UserId,
            UserName = user.UserName,
            Email = user.Email,
            MobileNo = user.MobileNo,
            PasswordHash = user.PasswordHash,
            IsActive = user.IsActive,
            IsLocked = user.IsLocked,
            LastLoginDate = user.LastLoginDate,
            CreatedBy = user.CreatedBy,
            CreatedDate = user.CreatedDate,
            ModifiedBy = user.ModifiedBy,
            ModifiedDate = user.ModifiedDate,
            RoleIds = user.RoleIds.ToList()
        };

        isEditMode = true;
    }

    private async Task SaveUserAsync()
    {
        var confirmed = await DialogService.Confirm(
            isEditMode ? "Do you want to update this user?" : "Do you want to save this user?",
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
                userForm.ModifiedDate = DateTime.Now;
                await UserWithRolesApiClient.UpdateAsync(userForm);
                Notify(NotificationSeverity.Success, "Success", "User updated successfully.");
            }
            else
            {
                userForm.CreatedDate = DateTime.Now;
                await UserWithRolesApiClient.CreateAsync(userForm);
                Notify(NotificationSeverity.Success, "Success", "User created successfully.");
            }

            await LoadDataAsync();
            ResetForm();
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to save user. {ex.Message}");
        }
    }

    private async Task DeleteUserAsync(UserWithRolesDto user)
    {
        var confirmed = await DialogService.Confirm(
            $"Delete user '{user.UserName}'?",
            "Confirmation",
            new ConfirmOptions { OkButtonText = "Yes", CancelButtonText = "No" });

        if (confirmed != true)
        {
            return;
        }

        try
        {
            await UserWithRolesApiClient.DeleteAsync(user.UserId);
            Notify(NotificationSeverity.Success, "Success", "User deleted successfully.");

            await LoadDataAsync();
            if (isEditMode && user.UserId == userForm.UserId)
            {
                ResetForm();
            }
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to delete user. {ex.Message}");
        }
    }

    private IEnumerable<string> GetRoleNames(IEnumerable<int> roleIds)
    {
        return availableRoles
            .Where(x => roleIds.Contains(x.RoleId))
            .Select(x => x.RoleName);
    }

    private void ResetForm()
    {
        userForm = new UserWithRolesDto
        {
            IsActive = true,
            IsLocked = false,
            RoleIds = new List<int>()
        };
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

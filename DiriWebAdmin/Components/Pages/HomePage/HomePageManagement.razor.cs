using Domain.DBModels;
using Microsoft.AspNetCore.Components;
using Radzen;
using Shared.AdminClientService.HomePage;

namespace DiriWebAdmin.Components.Pages.HomePage;

public partial class HomePageManagement : ComponentBase
{
    [Inject] private HomePageApiClient HomePageApiClient { get; set; } = default!;
    [Inject] private DialogService DialogService { get; set; } = default!;
    [Inject] private NotificationService NotificationService { get; set; } = default!;

    private List<BannerText> bannerTexts = new();
    private List<NumericDashboard> numericDashboards = new();
    private List<AboutU> aboutUsItems = new();
    private List<FounderInfo> founderInfos = new();
    private List<ManagingTrusteeInfo> managingTrusteeInfos = new();

    private BannerText bannerForm = CreateBannerForm();
    private NumericDashboard numericDashboardForm = CreateNumericDashboardForm();
    private AboutU aboutUsForm = CreateAboutUsForm();
    private FounderInfo founderInfoForm = CreateFounderInfoForm();
    private ManagingTrusteeInfo managingTrusteeInfoForm = CreateManagingTrusteeInfoForm();

    private bool isBannerEditMode;
    private bool isNumericDashboardEditMode;
    private bool isAboutUsEditMode;
    private bool isFounderInfoEditMode;
    private bool isManagingTrusteeInfoEditMode;

    private bool bannerActiveValue
    {
        get => bannerForm.Active == 1;
        set => bannerForm.Active = value ? 1 : 0;
    }

    private bool numericDashboardActiveValue
    {
        get => (numericDashboardForm.Active ?? 0) == 1;
        set => numericDashboardForm.Active = value ? 1 : 0;
    }

    private bool aboutUsActiveValue
    {
        get => (aboutUsForm.Active ?? 0) == 1;
        set => aboutUsForm.Active = value ? 1 : 0;
    }

    private bool founderInfoActiveValue
    {
        get => (founderInfoForm.Active ?? 0) == 1;
        set => founderInfoForm.Active = value ? 1 : 0;
    }

    private bool managingTrusteeInfoActiveValue
    {
        get => (managingTrusteeInfoForm.Active ?? 0) == 1;
        set => managingTrusteeInfoForm.Active = value ? 1 : 0;
    }

    protected override async Task OnInitializedAsync()
    {
        await LoadAllAsync();
    }

    private async Task LoadAllAsync()
    {
        bannerTexts = await HomePageApiClient.GetBannerTextsAsync();
        numericDashboards = await HomePageApiClient.GetNumericDashboardsAsync();
        aboutUsItems = await HomePageApiClient.GetAboutUsAsync();
        founderInfos = await HomePageApiClient.GetFounderInfosAsync();
        managingTrusteeInfos = await HomePageApiClient.GetManagingTrusteeInfosAsync();
    }

    private void EditBannerText(BannerText item)
    {
        bannerForm = new BannerText
        {
            Id = item.Id,
            BannerImageLocation = item.BannerImageLocation,
            TitleText = item.TitleText,
            Subtitle = item.Subtitle,
            Active = item.Active
        };
        isBannerEditMode = true;
    }

    private async Task SaveBannerTextAsync()
    {
        if (!await ConfirmSaveAsync(isBannerEditMode, "banner slide"))
        {
            return;
        }

        try
        {
            if (isBannerEditMode)
            {
                await HomePageApiClient.UpdateBannerTextAsync(bannerForm);
                Notify(NotificationSeverity.Success, "Success", "Banner slide updated successfully.");
            }
            else
            {
                await HomePageApiClient.CreateBannerTextAsync(bannerForm);
                Notify(NotificationSeverity.Success, "Success", "Banner slide created successfully.");
            }

            await LoadAllAsync();
            ResetBannerForm();
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to save banner slide. {ex.Message}");
        }
    }

    private async Task DeleteBannerTextAsync(BannerText item)
    {
        if (!await ConfirmDeleteAsync($"Delete banner slide '{item.TitleText}'?"))
        {
            return;
        }

        try
        {
            await HomePageApiClient.DeleteBannerTextAsync(item.Id);
            Notify(NotificationSeverity.Success, "Success", "Banner slide deleted successfully.");
            await LoadAllAsync();
            if (isBannerEditMode && bannerForm.Id == item.Id)
            {
                ResetBannerForm();
            }
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to delete banner slide. {ex.Message}");
        }
    }

    private void ResetBannerForm()
    {
        bannerForm = CreateBannerForm();
        isBannerEditMode = false;
    }

    private void EditNumericDashboard(NumericDashboard item)
    {
        numericDashboardForm = new NumericDashboard
        {
            Id = item.Id,
            TotalJournal = item.TotalJournal,
            ResearchTittle = item.ResearchTittle,
            UniversityInvolved = item.UniversityInvolved,
            Conference = item.Conference,
            Active = item.Active
        };
        isNumericDashboardEditMode = true;
    }

    private async Task SaveNumericDashboardAsync()
    {
        if (!await ConfirmSaveAsync(isNumericDashboardEditMode, "numeric dashboard"))
        {
            return;
        }

        try
        {
            if (isNumericDashboardEditMode)
            {
                await HomePageApiClient.UpdateNumericDashboardAsync(numericDashboardForm);
                Notify(NotificationSeverity.Success, "Success", "Numeric dashboard updated successfully.");
            }
            else
            {
                await HomePageApiClient.CreateNumericDashboardAsync(numericDashboardForm);
                Notify(NotificationSeverity.Success, "Success", "Numeric dashboard created successfully.");
            }

            await LoadAllAsync();
            ResetNumericDashboardForm();
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to save numeric dashboard. {ex.Message}");
        }
    }

    private async Task DeleteNumericDashboardAsync(NumericDashboard item)
    {
        if (!await ConfirmDeleteAsync($"Delete numeric dashboard record #{item.Id}?"))
        {
            return;
        }

        try
        {
            await HomePageApiClient.DeleteNumericDashboardAsync(item.Id);
            Notify(NotificationSeverity.Success, "Success", "Numeric dashboard deleted successfully.");
            await LoadAllAsync();
            if (isNumericDashboardEditMode && numericDashboardForm.Id == item.Id)
            {
                ResetNumericDashboardForm();
            }
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to delete numeric dashboard. {ex.Message}");
        }
    }

    private void ResetNumericDashboardForm()
    {
        numericDashboardForm = CreateNumericDashboardForm();
        isNumericDashboardEditMode = false;
    }

    private void EditAboutUs(AboutU item)
    {
        aboutUsForm = new AboutU
        {
            Id = item.Id,
            AboutUsTitle = item.AboutUsTitle,
            AbouUsText = item.AbouUsText,
            Active = item.Active
        };
        isAboutUsEditMode = true;
    }

    private async Task SaveAboutUsAsync()
    {
        if (!await ConfirmSaveAsync(isAboutUsEditMode, "about us section"))
        {
            return;
        }

        try
        {
            if (isAboutUsEditMode)
            {
                await HomePageApiClient.UpdateAboutUsAsync(aboutUsForm);
                Notify(NotificationSeverity.Success, "Success", "About us content updated successfully.");
            }
            else
            {
                await HomePageApiClient.CreateAboutUsAsync(aboutUsForm);
                Notify(NotificationSeverity.Success, "Success", "About us content created successfully.");
            }

            await LoadAllAsync();
            ResetAboutUsForm();
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to save about us content. {ex.Message}");
        }
    }

    private async Task DeleteAboutUsAsync(AboutU item)
    {
        if (!await ConfirmDeleteAsync($"Delete about us record '{item.AboutUsTitle}'?"))
        {
            return;
        }

        try
        {
            await HomePageApiClient.DeleteAboutUsAsync(item.Id);
            Notify(NotificationSeverity.Success, "Success", "About us content deleted successfully.");
            await LoadAllAsync();
            if (isAboutUsEditMode && aboutUsForm.Id == item.Id)
            {
                ResetAboutUsForm();
            }
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to delete about us content. {ex.Message}");
        }
    }

    private void ResetAboutUsForm()
    {
        aboutUsForm = CreateAboutUsForm();
        isAboutUsEditMode = false;
    }

    private void EditFounderInfo(FounderInfo item)
    {
        founderInfoForm = new FounderInfo
        {
            Id = item.Id,
            FounderName = item.FounderName,
            FounderTittle1 = item.FounderTittle1,
            FounderTittle2 = item.FounderTittle2,
            FounderMessage = item.FounderMessage,
            AboutFounder = item.AboutFounder,
            FounderImagePath = item.FounderImagePath,
            Active = item.Active,
            CreatedBy = item.CreatedBy,
            CreatedDate = item.CreatedDate,
            ModifiedBy = item.ModifiedBy,
            ModifiedDate = item.ModifiedDate
        };
        isFounderInfoEditMode = true;
    }

    private async Task SaveFounderInfoAsync()
    {
        if (!await ConfirmSaveAsync(isFounderInfoEditMode, "founder info"))
        {
            return;
        }

        try
        {
            if (isFounderInfoEditMode)
            {
                founderInfoForm.ModifiedDate = DateTime.Now;
                await HomePageApiClient.UpdateFounderInfoAsync(founderInfoForm);
                Notify(NotificationSeverity.Success, "Success", "Founder info updated successfully.");
            }
            else
            {
                founderInfoForm.CreatedDate = DateTime.Now;
                await HomePageApiClient.CreateFounderInfoAsync(founderInfoForm);
                Notify(NotificationSeverity.Success, "Success", "Founder info created successfully.");
            }

            await LoadAllAsync();
            ResetFounderInfoForm();
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to save founder info. {ex.Message}");
        }
    }

    private async Task DeleteFounderInfoAsync(FounderInfo item)
    {
        if (!await ConfirmDeleteAsync($"Delete founder record '{item.FounderName}'?"))
        {
            return;
        }

        try
        {
            await HomePageApiClient.DeleteFounderInfoAsync(item.Id);
            Notify(NotificationSeverity.Success, "Success", "Founder info deleted successfully.");
            await LoadAllAsync();
            if (isFounderInfoEditMode && founderInfoForm.Id == item.Id)
            {
                ResetFounderInfoForm();
            }
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to delete founder info. {ex.Message}");
        }
    }

    private void ResetFounderInfoForm()
    {
        founderInfoForm = CreateFounderInfoForm();
        isFounderInfoEditMode = false;
    }

    private void EditManagingTrusteeInfo(ManagingTrusteeInfo item)
    {
        managingTrusteeInfoForm = new ManagingTrusteeInfo
        {
            Id = item.Id,
            ManagingTrusteeName = item.ManagingTrusteeName,
            ManagingTrusteeNameTittle1 = item.ManagingTrusteeNameTittle1,
            ManagingTrusteeNameTittle2 = item.ManagingTrusteeNameTittle2,
            ManagingTrusteeMessage = item.ManagingTrusteeMessage,
            AboutManagingTrustee = item.AboutManagingTrustee,
            ManagingTrusteeImagePath = item.ManagingTrusteeImagePath,
            Active = item.Active,
            CreatedBy = item.CreatedBy,
            CreatedDate = item.CreatedDate,
            ModifiedBy = item.ModifiedBy,
            ModifiedDate = item.ModifiedDate
        };
        isManagingTrusteeInfoEditMode = true;
    }

    private async Task SaveManagingTrusteeInfoAsync()
    {
        if (!await ConfirmSaveAsync(isManagingTrusteeInfoEditMode, "managing trustee info"))
        {
            return;
        }

        try
        {
            if (isManagingTrusteeInfoEditMode)
            {
                managingTrusteeInfoForm.ModifiedDate = DateTime.Now;
                await HomePageApiClient.UpdateManagingTrusteeInfoAsync(managingTrusteeInfoForm);
                Notify(NotificationSeverity.Success, "Success", "Managing trustee info updated successfully.");
            }
            else
            {
                managingTrusteeInfoForm.CreatedDate = DateTime.Now;
                await HomePageApiClient.CreateManagingTrusteeInfoAsync(managingTrusteeInfoForm);
                Notify(NotificationSeverity.Success, "Success", "Managing trustee info created successfully.");
            }

            await LoadAllAsync();
            ResetManagingTrusteeInfoForm();
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to save managing trustee info. {ex.Message}");
        }
    }

    private async Task DeleteManagingTrusteeInfoAsync(ManagingTrusteeInfo item)
    {
        if (!await ConfirmDeleteAsync($"Delete managing trustee record '{item.ManagingTrusteeName}'?"))
        {
            return;
        }

        try
        {
            await HomePageApiClient.DeleteManagingTrusteeInfoAsync(item.Id);
            Notify(NotificationSeverity.Success, "Success", "Managing trustee info deleted successfully.");
            await LoadAllAsync();
            if (isManagingTrusteeInfoEditMode && managingTrusteeInfoForm.Id == item.Id)
            {
                ResetManagingTrusteeInfoForm();
            }
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to delete managing trustee info. {ex.Message}");
        }
    }

    private void ResetManagingTrusteeInfoForm()
    {
        managingTrusteeInfoForm = CreateManagingTrusteeInfoForm();
        isManagingTrusteeInfoEditMode = false;
    }

    private async Task<bool> ConfirmSaveAsync(bool isEditMode, string entityName)
    {
        var confirmed = await DialogService.Confirm(
            isEditMode ? $"Do you want to update this {entityName}?" : $"Do you want to save this {entityName}?",
            "Confirmation",
            new ConfirmOptions { OkButtonText = "Yes", CancelButtonText = "No" });

        return confirmed == true;
    }

    private async Task<bool> ConfirmDeleteAsync(string message)
    {
        var confirmed = await DialogService.Confirm(
            message,
            "Confirmation",
            new ConfirmOptions { OkButtonText = "Yes", CancelButtonText = "No" });

        return confirmed == true;
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

    private static BannerText CreateBannerForm() => new() { Active = 1 };

    private static NumericDashboard CreateNumericDashboardForm() => new() { Active = 1 };

    private static AboutU CreateAboutUsForm() => new() { Active = 1 };

    private static FounderInfo CreateFounderInfoForm() => new() { Active = 1 };

    private static ManagingTrusteeInfo CreateManagingTrusteeInfoForm() => new() { Active = 1 };
}

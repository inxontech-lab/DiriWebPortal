using Domain.DBModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Radzen;
using Shared.AdminClientService.HomePage;

namespace DiriWebAdmin.Components.Pages.HomePage;

public partial class HomePageManagement : ComponentBase
{
    private const long MaxUploadSize = 10 * 1024 * 1024;

    [Inject] private HomePageApiClient HomePageApiClient { get; set; } = default!;
    [Inject] private DialogService DialogService { get; set; } = default!;
    [Inject] private NotificationService NotificationService { get; set; } = default!;
    [Inject] private IWebHostEnvironment WebHostEnvironment { get; set; } = default!;

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

    private IBrowserFile? pendingBannerImageFile;
    private IBrowserFile? pendingFounderImageFile;
    private IBrowserFile? pendingManagingTrusteeImageFile;

    private string? pendingBannerImageFileName;
    private string? pendingFounderImageFileName;
    private string? pendingManagingTrusteeImageFileName;

    private bool isBannerEditMode;
    private bool isNumericDashboardEditMode;
    private bool isAboutUsEditMode;
    private bool isFounderInfoEditMode;
    private bool isManagingTrusteeInfoEditMode;

    private bool isBannerImagePopupVisible;
    private string bannerPopupTitle = string.Empty;
    private string bannerPopupImageSource = string.Empty;

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

        SyncFounderFormWithStoredRecord();
        SyncManagingTrusteeFormWithStoredRecord();
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

        pendingBannerImageFile = null;
        pendingBannerImageFileName = null;
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
            BannerText savedBanner;
            if (isBannerEditMode)
            {
                savedBanner = await HomePageApiClient.UpdateBannerTextAsync(bannerForm)
                    ?? throw new InvalidOperationException("Banner update did not return data.");
            }
            else
            {
                savedBanner = await HomePageApiClient.CreateBannerTextAsync(bannerForm)
                    ?? throw new InvalidOperationException("Banner create did not return data.");
            }

            if (pendingBannerImageFile is not null)
            {
                savedBanner.BannerImageLocation = await SaveHomePageImageAsync(pendingBannerImageFile, $"BannerText_{savedBanner.Id}");
                savedBanner = await HomePageApiClient.UpdateBannerTextAsync(savedBanner)
                    ?? throw new InvalidOperationException("Banner image update did not return data.");
            }

            Notify(NotificationSeverity.Success, "Success", isBannerEditMode ? "Banner slide updated successfully." : "Banner slide created successfully.");
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

    private Task HandleBannerImageSelected(InputFileChangeEventArgs args)
    {
        pendingBannerImageFile = args.File;
        pendingBannerImageFileName = args.File?.Name;
        return Task.CompletedTask;
    }

    private async Task OpenBannerImagePopupAsync(BannerText item)
    {
        var imageSource = await BuildPopupImageSourceAsync(item.BannerImageLocation);
        if (string.IsNullOrWhiteSpace(imageSource))
        {
            Notify(NotificationSeverity.Warning, "Image unavailable", "The selected banner image could not be loaded.");
            return;
        }

        bannerPopupTitle = string.IsNullOrWhiteSpace(item.TitleText) ? $"Banner #{item.Id}" : item.TitleText;
        bannerPopupImageSource = imageSource;
        isBannerImagePopupVisible = true;
    }

    private void CloseBannerImagePopup()
    {
        isBannerImagePopupVisible = false;
        bannerPopupTitle = string.Empty;
        bannerPopupImageSource = string.Empty;
    }

    private void ResetBannerForm()
    {
        bannerForm = CreateBannerForm();
        pendingBannerImageFile = null;
        pendingBannerImageFileName = null;
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

    private async Task SaveFounderInfoAsync()
    {
        if (!await ConfirmSaveAsync(isFounderInfoEditMode, "founder info"))
        {
            return;
        }

        try
        {
            FounderInfo savedFounderInfo;
            if (isFounderInfoEditMode)
            {
                founderInfoForm.ModifiedDate = DateTime.Now;
                savedFounderInfo = await HomePageApiClient.UpdateFounderInfoAsync(founderInfoForm)
                    ?? throw new InvalidOperationException("Founder info update did not return data.");
            }
            else
            {
                founderInfoForm.CreatedDate = DateTime.Now;
                savedFounderInfo = await HomePageApiClient.CreateFounderInfoAsync(founderInfoForm)
                    ?? throw new InvalidOperationException("Founder info create did not return data.");
            }

            if (pendingFounderImageFile is not null)
            {
                savedFounderInfo.FounderImagePath = await SaveHomePageImageAsync(pendingFounderImageFile, $"FounderInfo_{savedFounderInfo.Id}");
                savedFounderInfo = await HomePageApiClient.UpdateFounderInfoAsync(savedFounderInfo)
                    ?? throw new InvalidOperationException("Founder image update did not return data.");
            }

            Notify(NotificationSeverity.Success, "Success", isFounderInfoEditMode ? "Founder info updated successfully." : "Founder info created successfully.");
            await LoadAllAsync();
            ResetFounderInfoForm();
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to save founder info. {ex.Message}");
        }
    }

    private Task HandleFounderImageSelected(InputFileChangeEventArgs args)
    {
        pendingFounderImageFile = args.File;
        pendingFounderImageFileName = args.File?.Name;
        return Task.CompletedTask;
    }

    private void ResetFounderInfoForm()
    {
        pendingFounderImageFile = null;
        pendingFounderImageFileName = null;
        SyncFounderFormWithStoredRecord();
    }

    private async Task SaveManagingTrusteeInfoAsync()
    {
        if (!await ConfirmSaveAsync(isManagingTrusteeInfoEditMode, "managing trustee info"))
        {
            return;
        }

        try
        {
            ManagingTrusteeInfo savedManagingTrusteeInfo;
            if (isManagingTrusteeInfoEditMode)
            {
                managingTrusteeInfoForm.ModifiedDate = DateTime.Now;
                savedManagingTrusteeInfo = await HomePageApiClient.UpdateManagingTrusteeInfoAsync(managingTrusteeInfoForm)
                    ?? throw new InvalidOperationException("Managing trustee info update did not return data.");
            }
            else
            {
                managingTrusteeInfoForm.CreatedDate = DateTime.Now;
                savedManagingTrusteeInfo = await HomePageApiClient.CreateManagingTrusteeInfoAsync(managingTrusteeInfoForm)
                    ?? throw new InvalidOperationException("Managing trustee info create did not return data.");
            }

            if (pendingManagingTrusteeImageFile is not null)
            {
                savedManagingTrusteeInfo.ManagingTrusteeImagePath = await SaveHomePageImageAsync(pendingManagingTrusteeImageFile, $"ManagingTrusteeInfo_{savedManagingTrusteeInfo.Id}");
                savedManagingTrusteeInfo = await HomePageApiClient.UpdateManagingTrusteeInfoAsync(savedManagingTrusteeInfo)
                    ?? throw new InvalidOperationException("Managing trustee image update did not return data.");
            }

            Notify(NotificationSeverity.Success, "Success", isManagingTrusteeInfoEditMode ? "Managing trustee info updated successfully." : "Managing trustee info created successfully.");
            await LoadAllAsync();
            ResetManagingTrusteeInfoForm();
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to save managing trustee info. {ex.Message}");
        }
    }

    private Task HandleManagingTrusteeImageSelected(InputFileChangeEventArgs args)
    {
        pendingManagingTrusteeImageFile = args.File;
        pendingManagingTrusteeImageFileName = args.File?.Name;
        return Task.CompletedTask;
    }

    private void ResetManagingTrusteeInfoForm()
    {
        pendingManagingTrusteeImageFile = null;
        pendingManagingTrusteeImageFileName = null;
        SyncManagingTrusteeFormWithStoredRecord();
    }

    private void SyncFounderFormWithStoredRecord()
    {
        var storedFounderInfo = founderInfos.OrderBy(x => x.Id).FirstOrDefault();
        if (storedFounderInfo is null)
        {
            founderInfoForm = CreateFounderInfoForm();
            isFounderInfoEditMode = false;
            return;
        }

        founderInfoForm = CloneFounderInfo(storedFounderInfo);
        isFounderInfoEditMode = true;
    }

    private void SyncManagingTrusteeFormWithStoredRecord()
    {
        var storedManagingTrusteeInfo = managingTrusteeInfos.OrderBy(x => x.Id).FirstOrDefault();
        if (storedManagingTrusteeInfo is null)
        {
            managingTrusteeInfoForm = CreateManagingTrusteeInfoForm();
            isManagingTrusteeInfoEditMode = false;
            return;
        }

        managingTrusteeInfoForm = CloneManagingTrusteeInfo(storedManagingTrusteeInfo);
        isManagingTrusteeInfoEditMode = true;
    }

    private async Task<string?> BuildPopupImageSourceAsync(string? storedPath)
    {
        if (string.IsNullOrWhiteSpace(storedPath))
        {
            return null;
        }

        var normalizedPath = storedPath.TrimStart('~', '/').Replace('/', Path.DirectorySeparatorChar);
        var portalFilePath = Path.Combine(GetPortalWwwRootPath(), normalizedPath);
        if (File.Exists(portalFilePath))
        {
            var bytes = await File.ReadAllBytesAsync(portalFilePath);
            return $"data:{GetContentType(portalFilePath)};base64,{Convert.ToBase64String(bytes)}";
        }

        var adminFilePath = Path.Combine(GetAdminWwwRootPath(), normalizedPath);
        if (File.Exists(adminFilePath))
        {
            var bytes = await File.ReadAllBytesAsync(adminFilePath);
            return $"data:{GetContentType(adminFilePath)};base64,{Convert.ToBase64String(bytes)}";
        }

        return ResolveImageUrl(storedPath);
    }

    private async Task<string> SaveHomePageImageAsync(IBrowserFile file, string fileStem)
    {
        var extension = Path.GetExtension(file.Name);
        if (string.IsNullOrWhiteSpace(extension))
        {
            extension = ".png";
        }

        var fileName = $"{fileStem}{extension.ToLowerInvariant()}";
        var relativePath = $"HomePage/{fileName}";
        var portalTargetFolder = GetPortalHomePageFolderPath();
        var adminTargetFolder = GetAdminHomePageFolderPath();

        Directory.CreateDirectory(portalTargetFolder);
        Directory.CreateDirectory(adminTargetFolder);
        DeleteExistingEntityImages(portalTargetFolder, fileStem);
        DeleteExistingEntityImages(adminTargetFolder, fileStem);

        await using var fileStream = file.OpenReadStream(MaxUploadSize);
        await using var memoryStream = new MemoryStream();
        await fileStream.CopyToAsync(memoryStream);
        var buffer = memoryStream.ToArray();

        await File.WriteAllBytesAsync(Path.Combine(portalTargetFolder, fileName), buffer);
        await File.WriteAllBytesAsync(Path.Combine(adminTargetFolder, fileName), buffer);

        return relativePath;
    }

    private void DeleteExistingEntityImages(string folderPath, string fileStem)
    {
        foreach (var existingFile in Directory.GetFiles(folderPath, $"{fileStem}.*"))
        {
            File.Delete(existingFile);
        }
    }

    private string GetBannerImageStatusText()
    {
        if (!string.IsNullOrWhiteSpace(pendingBannerImageFileName))
        {
            return $"Selected image: {pendingBannerImageFileName}";
        }

        return string.IsNullOrWhiteSpace(bannerForm.BannerImageLocation)
            ? "No image selected."
            : $"Current image: {bannerForm.BannerImageLocation}";
    }

    private string GetFounderImageStatusText()
    {
        if (!string.IsNullOrWhiteSpace(pendingFounderImageFileName))
        {
            return $"Selected image: {pendingFounderImageFileName}";
        }

        return string.IsNullOrWhiteSpace(founderInfoForm.FounderImagePath)
            ? "No image selected."
            : $"Current image: {founderInfoForm.FounderImagePath}";
    }

    private string GetManagingTrusteeImageStatusText()
    {
        if (!string.IsNullOrWhiteSpace(pendingManagingTrusteeImageFileName))
        {
            return $"Selected image: {pendingManagingTrusteeImageFileName}";
        }

        return string.IsNullOrWhiteSpace(managingTrusteeInfoForm.ManagingTrusteeImagePath)
            ? "No image selected."
            : $"Current image: {managingTrusteeInfoForm.ManagingTrusteeImagePath}";
    }

    private string GetPortalWwwRootPath() => Path.GetFullPath(Path.Combine(WebHostEnvironment.ContentRootPath, "..", "DiriWebPortal", "wwwroot"));

    private string GetPortalHomePageFolderPath() => Path.Combine(GetPortalWwwRootPath(), "HomePage");

    private string GetAdminWwwRootPath() => WebHostEnvironment.WebRootPath ?? Path.Combine(WebHostEnvironment.ContentRootPath, "wwwroot");

    private string GetAdminHomePageFolderPath() => Path.Combine(GetAdminWwwRootPath(), "HomePage");

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

    private static FounderInfo CloneFounderInfo(FounderInfo item) => new()
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

    private static ManagingTrusteeInfo CloneManagingTrusteeInfo(ManagingTrusteeInfo item) => new()
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

    private static string GetContentType(string filePath)
    {
        return Path.GetExtension(filePath).ToLowerInvariant() switch
        {
            ".png" => "image/png",
            ".gif" => "image/gif",
            ".webp" => "image/webp",
            ".svg" => "image/svg+xml",
            _ => "image/jpeg"
        };
    }

    private static string ResolveImageUrl(string? path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return string.Empty;
        }

        if (Uri.TryCreate(path, UriKind.Absolute, out _))
        {
            return path;
        }

        return path.StartsWith('/') ? path : $"/{path.TrimStart('~', '/')}";
    }

    private static BannerText CreateBannerForm() => new() { Active = 1 };

    private static NumericDashboard CreateNumericDashboardForm() => new() { Active = 1 };

    private static AboutU CreateAboutUsForm() => new() { Active = 1 };

    private static FounderInfo CreateFounderInfoForm() => new() { Active = 1 };

    private static ManagingTrusteeInfo CreateManagingTrusteeInfoForm() => new() { Active = 1 };
}

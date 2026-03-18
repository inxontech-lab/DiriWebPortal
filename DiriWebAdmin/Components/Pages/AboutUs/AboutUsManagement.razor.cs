using Domain.DBModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Radzen;
using Shared.AdminClientService.AboutUs;

namespace DiriWebAdmin.Components.Pages.AboutUs;

public partial class AboutUsManagement : ComponentBase
{
    private const long MaxUploadSize = 10 * 1024 * 1024;

    [Inject] private AboutUsApiClient AboutUsApiClient { get; set; } = default!;
    [Inject] private DialogService DialogService { get; set; } = default!;
    [Inject] private NotificationService NotificationService { get; set; } = default!;
    [Inject] private IWebHostEnvironment WebHostEnvironment { get; set; } = default!;

    private readonly List<PlannedSection> plannedSections =
    [
        new("Our Vision", "Reserved for future content management."),
        new("DIRI Committee", "Reserved for future committee management."),
        new("DIRI Research Cell", "Reserved for future research cell management."),
        new("Collaborations", "Reserved for future collaboration management.")
    ];

    private List<FounderInfo> founderInfos = new();
    private List<ManagingTrusteeInfo> managingTrusteeInfos = new();
    private List<ManagingTrusteeDesignation> managingTrusteeDesignations = new();
    private List<ManagingTrusteeArticle> managingTrusteeArticles = new();
    private List<ManagingTrusteePublication> managingTrusteePublications = new();
    private List<AboutUsDetail> aboutUsDetails = new();

    private FounderInfo founderInfoForm = CreateFounderInfoForm();
    private ManagingTrusteeInfo managingTrusteeInfoForm = CreateManagingTrusteeInfoForm();
    private ManagingTrusteeDesignation managingTrusteeDesignationForm = CreateManagingTrusteeDesignationForm();
    private ManagingTrusteeArticle managingTrusteeArticleForm = CreateManagingTrusteeArticleForm();
    private ManagingTrusteePublication managingTrusteePublicationForm = CreateManagingTrusteePublicationForm();
    private AboutUsDetail aboutUsDetailForm = CreateAboutUsDetailForm();

    private IBrowserFile? pendingFounderImageFile;
    private IBrowserFile? pendingManagingTrusteeImageFile;
    private string? pendingFounderImageFileName;
    private string? pendingManagingTrusteeImageFileName;

    private bool isFounderInfoEditMode;
    private bool isManagingTrusteeInfoEditMode;
    private bool isManagingTrusteeDesignationEditMode;
    private bool isManagingTrusteeArticleEditMode;
    private bool isManagingTrusteePublicationEditMode;
    private bool isAboutUsDetailEditMode;

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

    private bool managingTrusteeDesignationActiveValue
    {
        get => (managingTrusteeDesignationForm.Active ?? 0) == 1;
        set => managingTrusteeDesignationForm.Active = value ? 1 : 0;
    }

    private bool managingTrusteeArticleActiveValue
    {
        get => (managingTrusteeArticleForm.Active ?? 0) == 1;
        set => managingTrusteeArticleForm.Active = value ? 1 : 0;
    }

    private bool managingTrusteePublicationActiveValue
    {
        get => (managingTrusteePublicationForm.Active ?? 0) == 1;
        set => managingTrusteePublicationForm.Active = value ? 1 : 0;
    }

    private bool aboutUsDetailActiveValue
    {
        get => (aboutUsDetailForm.Active ?? 0) == 1;
        set => aboutUsDetailForm.Active = value ? 1 : 0;
    }

    protected override async Task OnInitializedAsync()
    {
        await LoadAllAsync();
    }

    private async Task LoadAllAsync()
    {
        founderInfos = await AboutUsApiClient.GetFounderInfosAsync();
        managingTrusteeInfos = await AboutUsApiClient.GetManagingTrusteeInfosAsync();
        managingTrusteeDesignations = await AboutUsApiClient.GetManagingTrusteeDesignationsAsync();
        managingTrusteeArticles = await AboutUsApiClient.GetManagingTrusteeArticlesAsync();
        managingTrusteePublications = await AboutUsApiClient.GetManagingTrusteePublicationsAsync();
        aboutUsDetails = await AboutUsApiClient.GetAboutUsDetailsAsync();

        SyncFounderFormWithStoredRecord();
        SyncManagingTrusteeFormWithStoredRecord();
    }

    private async Task SaveFounderInfoAsync()
    {
        if (!await ConfirmSaveAsync(isFounderInfoEditMode, "founder message"))
        {
            return;
        }

        try
        {
            FounderInfo savedFounderInfo;
            if (isFounderInfoEditMode)
            {
                founderInfoForm.ModifiedDate = DateTime.Now;
                savedFounderInfo = await AboutUsApiClient.UpdateFounderInfoAsync(founderInfoForm)
                    ?? throw new InvalidOperationException("Founder info update did not return data.");
            }
            else
            {
                founderInfoForm.CreatedDate = DateTime.Now;
                savedFounderInfo = await AboutUsApiClient.CreateFounderInfoAsync(founderInfoForm)
                    ?? throw new InvalidOperationException("Founder info create did not return data.");
            }

            if (pendingFounderImageFile is not null)
            {
                savedFounderInfo.FounderImagePath = await SaveHomePageImageAsync(pendingFounderImageFile, $"FounderInfo_{savedFounderInfo.Id}");
                savedFounderInfo = await AboutUsApiClient.UpdateFounderInfoAsync(savedFounderInfo)
                    ?? throw new InvalidOperationException("Founder image update did not return data.");
            }

            Notify(NotificationSeverity.Success, "Success", isFounderInfoEditMode ? "Founder message updated successfully." : "Founder message created successfully.");
            await LoadAllAsync();
            ResetFounderInfoFormState();
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to save founder message. {ex.Message}");
        }
    }

    private async Task DeleteFounderInfoAsync()
    {
        if (!isFounderInfoEditMode || founderInfoForm.Id <= 0)
        {
            return;
        }

        if (!await ConfirmDeleteAsync($"Delete founder message '{founderInfoForm.FounderName}'?"))
        {
            return;
        }

        try
        {
            await AboutUsApiClient.DeleteFounderInfoAsync(founderInfoForm.Id);
            Notify(NotificationSeverity.Success, "Success", "Founder message deleted successfully.");
            await LoadAllAsync();
            ResetFounderInfoFormState();
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to delete founder message. {ex.Message}");
        }
    }

    private Task OnFounderImageFileChanged(InputFileChangeEventArgs args)
    {
        pendingFounderImageFile = args.File;
        pendingFounderImageFileName = args.File?.Name;
        return Task.CompletedTask;
    }

    private void ResetFounderInfoFormState()
    {
        pendingFounderImageFile = null;
        pendingFounderImageFileName = null;
        SyncFounderFormWithStoredRecord();
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

    private async Task SaveManagingTrusteeInfoAsync()
    {
        if (!await ConfirmSaveAsync(isManagingTrusteeInfoEditMode, "managing trustee profile"))
        {
            return;
        }

        try
        {
            ManagingTrusteeInfo savedManagingTrusteeInfo;
            if (isManagingTrusteeInfoEditMode)
            {
                managingTrusteeInfoForm.ModifiedDate = DateTime.Now;
                savedManagingTrusteeInfo = await AboutUsApiClient.UpdateManagingTrusteeInfoAsync(managingTrusteeInfoForm)
                    ?? throw new InvalidOperationException("Managing trustee info update did not return data.");
            }
            else
            {
                managingTrusteeInfoForm.CreatedDate = DateTime.Now;
                savedManagingTrusteeInfo = await AboutUsApiClient.CreateManagingTrusteeInfoAsync(managingTrusteeInfoForm)
                    ?? throw new InvalidOperationException("Managing trustee info create did not return data.");
            }

            if (pendingManagingTrusteeImageFile is not null)
            {
                savedManagingTrusteeInfo.ManagingTrusteeImagePath = await SaveHomePageImageAsync(pendingManagingTrusteeImageFile, $"ManagingTrusteeInfo_{savedManagingTrusteeInfo.Id}");
                savedManagingTrusteeInfo = await AboutUsApiClient.UpdateManagingTrusteeInfoAsync(savedManagingTrusteeInfo)
                    ?? throw new InvalidOperationException("Managing trustee image update did not return data.");
            }

            Notify(NotificationSeverity.Success, "Success", isManagingTrusteeInfoEditMode ? "Managing trustee profile updated successfully." : "Managing trustee profile created successfully.");
            await LoadAllAsync();
            ResetManagingTrusteeInfoFormState();
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to save managing trustee profile. {ex.Message}");
        }
    }

    private async Task DeleteManagingTrusteeInfoAsync()
    {
        if (!isManagingTrusteeInfoEditMode || managingTrusteeInfoForm.Id <= 0)
        {
            return;
        }

        if (!await ConfirmDeleteAsync($"Delete managing trustee profile '{managingTrusteeInfoForm.ManagingTrusteeName}'?"))
        {
            return;
        }

        try
        {
            await AboutUsApiClient.DeleteManagingTrusteeInfoAsync(managingTrusteeInfoForm.Id);
            Notify(NotificationSeverity.Success, "Success", "Managing trustee profile deleted successfully.");
            await LoadAllAsync();
            ResetManagingTrusteeInfoFormState();
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to delete managing trustee profile. {ex.Message}");
        }
    }

    private Task OnManagingTrusteeImageFileChanged(InputFileChangeEventArgs args)
    {
        pendingManagingTrusteeImageFile = args.File;
        pendingManagingTrusteeImageFileName = args.File?.Name;
        return Task.CompletedTask;
    }

    private void ResetManagingTrusteeInfoFormState()
    {
        pendingManagingTrusteeImageFile = null;
        pendingManagingTrusteeImageFileName = null;
        SyncManagingTrusteeFormWithStoredRecord();
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

    private void EditManagingTrusteeDesignation(ManagingTrusteeDesignation item)
    {
        managingTrusteeDesignationForm = CloneManagingTrusteeDesignation(item);
        isManagingTrusteeDesignationEditMode = true;
    }

    private async Task SaveManagingTrusteeDesignationAsync()
    {
        if (!await ConfirmSaveAsync(isManagingTrusteeDesignationEditMode, "managing trustee designation"))
        {
            return;
        }

        try
        {
            if (isManagingTrusteeDesignationEditMode)
            {
                await AboutUsApiClient.UpdateManagingTrusteeDesignationAsync(managingTrusteeDesignationForm);
                Notify(NotificationSeverity.Success, "Success", "Designation updated successfully.");
            }
            else
            {
                await AboutUsApiClient.CreateManagingTrusteeDesignationAsync(managingTrusteeDesignationForm);
                Notify(NotificationSeverity.Success, "Success", "Designation created successfully.");
            }

            managingTrusteeDesignations = await AboutUsApiClient.GetManagingTrusteeDesignationsAsync();
            ResetManagingTrusteeDesignationFormState();
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to save designation. {ex.Message}");
        }
    }

    private async Task DeleteManagingTrusteeDesignationAsync(ManagingTrusteeDesignation item)
    {
        if (!await ConfirmDeleteAsync($"Delete designation '{item.DesignationDetails}'?"))
        {
            return;
        }

        try
        {
            await AboutUsApiClient.DeleteManagingTrusteeDesignationAsync(item.Id);
            managingTrusteeDesignations = await AboutUsApiClient.GetManagingTrusteeDesignationsAsync();
            if (isManagingTrusteeDesignationEditMode && managingTrusteeDesignationForm.Id == item.Id)
            {
                ResetManagingTrusteeDesignationFormState();
            }
            Notify(NotificationSeverity.Success, "Success", "Designation deleted successfully.");
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to delete designation. {ex.Message}");
        }
    }

    private void ResetManagingTrusteeDesignationFormState()
    {
        managingTrusteeDesignationForm = CreateManagingTrusteeDesignationForm();
        isManagingTrusteeDesignationEditMode = false;
    }

    private void EditManagingTrusteeArticle(ManagingTrusteeArticle item)
    {
        managingTrusteeArticleForm = CloneManagingTrusteeArticle(item);
        isManagingTrusteeArticleEditMode = true;
    }

    private async Task SaveManagingTrusteeArticleAsync()
    {
        if (!await ConfirmSaveAsync(isManagingTrusteeArticleEditMode, "managing trustee article"))
        {
            return;
        }

        try
        {
            if (isManagingTrusteeArticleEditMode)
            {
                await AboutUsApiClient.UpdateManagingTrusteeArticleAsync(managingTrusteeArticleForm);
                Notify(NotificationSeverity.Success, "Success", "Article updated successfully.");
            }
            else
            {
                await AboutUsApiClient.CreateManagingTrusteeArticleAsync(managingTrusteeArticleForm);
                Notify(NotificationSeverity.Success, "Success", "Article created successfully.");
            }

            managingTrusteeArticles = await AboutUsApiClient.GetManagingTrusteeArticlesAsync();
            ResetManagingTrusteeArticleFormState();
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to save article. {ex.Message}");
        }
    }

    private async Task DeleteManagingTrusteeArticleAsync(ManagingTrusteeArticle item)
    {
        if (!await ConfirmDeleteAsync($"Delete article '{item.ArticleName}'?"))
        {
            return;
        }

        try
        {
            await AboutUsApiClient.DeleteManagingTrusteeArticleAsync(item.Id);
            managingTrusteeArticles = await AboutUsApiClient.GetManagingTrusteeArticlesAsync();
            if (isManagingTrusteeArticleEditMode && managingTrusteeArticleForm.Id == item.Id)
            {
                ResetManagingTrusteeArticleFormState();
            }
            Notify(NotificationSeverity.Success, "Success", "Article deleted successfully.");
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to delete article. {ex.Message}");
        }
    }

    private void ResetManagingTrusteeArticleFormState()
    {
        managingTrusteeArticleForm = CreateManagingTrusteeArticleForm();
        isManagingTrusteeArticleEditMode = false;
    }

    private void EditManagingTrusteePublication(ManagingTrusteePublication item)
    {
        managingTrusteePublicationForm = CloneManagingTrusteePublication(item);
        isManagingTrusteePublicationEditMode = true;
    }

    private async Task SaveManagingTrusteePublicationAsync()
    {
        if (!await ConfirmSaveAsync(isManagingTrusteePublicationEditMode, "managing trustee publication"))
        {
            return;
        }

        try
        {
            if (isManagingTrusteePublicationEditMode)
            {
                await AboutUsApiClient.UpdateManagingTrusteePublicationAsync(managingTrusteePublicationForm);
                Notify(NotificationSeverity.Success, "Success", "Publication updated successfully.");
            }
            else
            {
                await AboutUsApiClient.CreateManagingTrusteePublicationAsync(managingTrusteePublicationForm);
                Notify(NotificationSeverity.Success, "Success", "Publication created successfully.");
            }

            managingTrusteePublications = await AboutUsApiClient.GetManagingTrusteePublicationsAsync();
            ResetManagingTrusteePublicationFormState();
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to save publication. {ex.Message}");
        }
    }

    private async Task DeleteManagingTrusteePublicationAsync(ManagingTrusteePublication item)
    {
        if (!await ConfirmDeleteAsync($"Delete publication '{item.PublicationName}'?"))
        {
            return;
        }

        try
        {
            await AboutUsApiClient.DeleteManagingTrusteePublicationAsync(item.Id);
            managingTrusteePublications = await AboutUsApiClient.GetManagingTrusteePublicationsAsync();
            if (isManagingTrusteePublicationEditMode && managingTrusteePublicationForm.Id == item.Id)
            {
                ResetManagingTrusteePublicationFormState();
            }
            Notify(NotificationSeverity.Success, "Success", "Publication deleted successfully.");
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to delete publication. {ex.Message}");
        }
    }

    private void ResetManagingTrusteePublicationFormState()
    {
        managingTrusteePublicationForm = CreateManagingTrusteePublicationForm();
        isManagingTrusteePublicationEditMode = false;
    }

    private void EditAboutUsDetail(AboutUsDetail item)
    {
        aboutUsDetailForm = CloneAboutUsDetail(item);
        isAboutUsDetailEditMode = true;
    }

    private async Task SaveAboutUsDetailAsync()
    {
        if (!await ConfirmSaveAsync(isAboutUsDetailEditMode, "DIRI at a glance record"))
        {
            return;
        }

        try
        {
            if (isAboutUsDetailEditMode)
            {
                await AboutUsApiClient.UpdateAboutUsDetailAsync(aboutUsDetailForm);
                Notify(NotificationSeverity.Success, "Success", "DIRI at a glance updated successfully.");
            }
            else
            {
                await AboutUsApiClient.CreateAboutUsDetailAsync(aboutUsDetailForm);
                Notify(NotificationSeverity.Success, "Success", "DIRI at a glance created successfully.");
            }

            aboutUsDetails = await AboutUsApiClient.GetAboutUsDetailsAsync();
            ResetAboutUsDetailFormState();
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to save DIRI at a glance. {ex.Message}");
        }
    }

    private async Task DeleteAboutUsDetailAsync(AboutUsDetail item)
    {
        if (!await ConfirmDeleteAsync($"Delete DIRI at a glance record #{item.Id}?"))
        {
            return;
        }

        try
        {
            await AboutUsApiClient.DeleteAboutUsDetailAsync(item.Id);
            aboutUsDetails = await AboutUsApiClient.GetAboutUsDetailsAsync();
            if (isAboutUsDetailEditMode && aboutUsDetailForm.Id == item.Id)
            {
                ResetAboutUsDetailFormState();
            }
            Notify(NotificationSeverity.Success, "Success", "DIRI at a glance deleted successfully.");
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to delete DIRI at a glance. {ex.Message}");
        }
    }

    private void ResetAboutUsDetailFormState()
    {
        aboutUsDetailForm = CreateAboutUsDetailForm();
        isAboutUsDetailEditMode = false;
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

    private int GetActiveRecordCount()
    {
        return founderInfos.Count(x => x.Active == 1)
            + managingTrusteeInfos.Count(x => x.Active == 1)
            + managingTrusteeDesignations.Count(x => x.Active == 1)
            + managingTrusteeArticles.Count(x => x.Active == 1)
            + managingTrusteePublications.Count(x => x.Active == 1)
            + aboutUsDetails.Count(x => x.Active == 1);
    }

    private RenderFragment RenderSimpleGridCard(string title, int count, RenderFragment content) => builder =>
    {
        builder.OpenElement(0, "div");
        builder.AddAttribute(1, "class", "card aboutus-form-card h-100");
        builder.OpenElement(2, "div");
        builder.AddAttribute(3, "class", "card-header d-flex justify-content-between align-items-center");
        builder.AddContent(4, title);
        builder.OpenElement(5, "span");
        builder.AddAttribute(6, "class", "badge text-bg-light");
        builder.AddContent(7, count);
        builder.CloseElement();
        builder.CloseElement();
        builder.OpenElement(8, "div");
        builder.AddAttribute(9, "class", "card-body");
        builder.AddContent(10, content);
        builder.CloseElement();
        builder.CloseElement();
    };

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

    private static ManagingTrusteeDesignation CloneManagingTrusteeDesignation(ManagingTrusteeDesignation item) => new()
    {
        Id = item.Id,
        DesignationDetails = item.DesignationDetails,
        Active = item.Active
    };

    private static ManagingTrusteeArticle CloneManagingTrusteeArticle(ManagingTrusteeArticle item) => new()
    {
        Id = item.Id,
        ArticleName = item.ArticleName,
        ShortDescription = item.ShortDescription,
        ArticleLink = item.ArticleLink,
        PublishedDate = item.PublishedDate,
        Active = item.Active
    };

    private static ManagingTrusteePublication CloneManagingTrusteePublication(ManagingTrusteePublication item) => new()
    {
        Id = item.Id,
        PublicationName = item.PublicationName,
        ShortDescription = item.ShortDescription,
        PublicationLink = item.PublicationLink,
        PublishedDate = item.PublishedDate,
        Active = item.Active
    };

    private static AboutUsDetail CloneAboutUsDetail(AboutUsDetail item) => new()
    {
        Id = item.Id,
        Heading1 = item.Heading1,
        Heading2 = item.Heading2,
        Heading3 = item.Heading3,
        Heading4 = item.Heading4,
        AboutUsDetails = item.AboutUsDetails,
        YearsOfJourney = item.YearsOfJourney,
        Active = item.Active
    };

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

    private static FounderInfo CreateFounderInfoForm() => new() { Active = 1 };
    private static ManagingTrusteeInfo CreateManagingTrusteeInfoForm() => new() { Active = 1 };
    private static ManagingTrusteeDesignation CreateManagingTrusteeDesignationForm() => new() { Active = 1 };
    private static ManagingTrusteeArticle CreateManagingTrusteeArticleForm() => new() { Active = 1, PublishedDate = DateTime.Today };
    private static ManagingTrusteePublication CreateManagingTrusteePublicationForm() => new() { Active = 1, PublishedDate = DateTime.Today };
    private static AboutUsDetail CreateAboutUsDetailForm() => new() { Active = 1 };

    private sealed record PlannedSection(string Title, string Description);
}

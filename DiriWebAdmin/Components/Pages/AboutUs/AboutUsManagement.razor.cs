using Domain.DBModels;
using Microsoft.AspNetCore.Components;
using Radzen;
using Shared.AdminClientService.AboutUs;

namespace DiriWebAdmin.Components.Pages.AboutUs;

public partial class AboutUsManagement : ComponentBase
{
    [Inject] private AboutUsApiClient AboutUsApiClient { get; set; } = default!;
    [Inject] private DialogService DialogService { get; set; } = default!;
    [Inject] private NotificationService NotificationService { get; set; } = default!;

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

    private bool isFounderInfoEditMode;
    private bool isManagingTrusteeInfoEditMode;
    private bool isManagingTrusteeDesignationEditMode;
    private bool isManagingTrusteeArticleEditMode;
    private bool isManagingTrusteePublicationEditMode;
    private bool isAboutUsDetailEditMode;

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
        SyncAboutUsDetailFormWithStoredRecord();
    }

    private async Task SaveFounderInfoAsync()
    {
        if (!await ConfirmSaveAsync(isFounderInfoEditMode, "founder message"))
        {
            return;
        }

        try
        {
            founderInfoForm.ModifiedDate = DateTime.Now;
            if (isFounderInfoEditMode)
            {
                await AboutUsApiClient.UpdateFounderInfoAsync(founderInfoForm);
            }
            else
            {
                founderInfoForm.CreatedDate = DateTime.Now;
                await AboutUsApiClient.CreateFounderInfoAsync(founderInfoForm);
            }

            Notify(NotificationSeverity.Success, "Success", isFounderInfoEditMode ? "Founder content updated successfully." : "Founder content created successfully.");
            await LoadAllAsync();
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to save founder content. {ex.Message}");
        }
    }

    private async Task DeleteFounderInfoAsync()
    {
        if (!isFounderInfoEditMode || founderInfoForm.Id <= 0)
        {
            return;
        }

        if (!await ConfirmDeleteAsync($"Delete founder content for '{founderInfoForm.FounderName}'?"))
        {
            return;
        }

        try
        {
            await AboutUsApiClient.DeleteFounderInfoAsync(founderInfoForm.Id);
            Notify(NotificationSeverity.Success, "Success", "Founder content deleted successfully.");
            await LoadAllAsync();
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to delete founder content. {ex.Message}");
        }
    }

    private void ResetFounderInfoFormState() => SyncFounderFormWithStoredRecord();

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
            managingTrusteeInfoForm.ModifiedDate = DateTime.Now;
            if (isManagingTrusteeInfoEditMode)
            {
                await AboutUsApiClient.UpdateManagingTrusteeInfoAsync(managingTrusteeInfoForm);
            }
            else
            {
                managingTrusteeInfoForm.CreatedDate = DateTime.Now;
                await AboutUsApiClient.CreateManagingTrusteeInfoAsync(managingTrusteeInfoForm);
            }

            Notify(NotificationSeverity.Success, "Success", isManagingTrusteeInfoEditMode ? "Managing trustee profile updated successfully." : "Managing trustee profile created successfully.");
            await LoadAllAsync();
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

        if (!await ConfirmDeleteAsync($"Delete managing trustee profile for '{managingTrusteeInfoForm.ManagingTrusteeName}'?"))
        {
            return;
        }

        try
        {
            await AboutUsApiClient.DeleteManagingTrusteeInfoAsync(managingTrusteeInfoForm.Id);
            Notify(NotificationSeverity.Success, "Success", "Managing trustee profile deleted successfully.");
            await LoadAllAsync();
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to delete managing trustee profile. {ex.Message}");
        }
    }

    private void ResetManagingTrusteeInfoFormState() => SyncManagingTrusteeFormWithStoredRecord();

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
            }
            else
            {
                await AboutUsApiClient.CreateManagingTrusteeDesignationAsync(managingTrusteeDesignationForm);
            }

            Notify(NotificationSeverity.Success, "Success", isManagingTrusteeDesignationEditMode ? "Designation updated successfully." : "Designation created successfully.");
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
            Notify(NotificationSeverity.Success, "Success", "Designation deleted successfully.");
            managingTrusteeDesignations = await AboutUsApiClient.GetManagingTrusteeDesignationsAsync();
            if (isManagingTrusteeDesignationEditMode && managingTrusteeDesignationForm.Id == item.Id)
            {
                ResetManagingTrusteeDesignationFormState();
            }
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
            }
            else
            {
                await AboutUsApiClient.CreateManagingTrusteeArticleAsync(managingTrusteeArticleForm);
            }

            Notify(NotificationSeverity.Success, "Success", isManagingTrusteeArticleEditMode ? "Article updated successfully." : "Article created successfully.");
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
            Notify(NotificationSeverity.Success, "Success", "Article deleted successfully.");
            managingTrusteeArticles = await AboutUsApiClient.GetManagingTrusteeArticlesAsync();
            if (isManagingTrusteeArticleEditMode && managingTrusteeArticleForm.Id == item.Id)
            {
                ResetManagingTrusteeArticleFormState();
            }
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
            }
            else
            {
                await AboutUsApiClient.CreateManagingTrusteePublicationAsync(managingTrusteePublicationForm);
            }

            Notify(NotificationSeverity.Success, "Success", isManagingTrusteePublicationEditMode ? "Publication updated successfully." : "Publication created successfully.");
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
            Notify(NotificationSeverity.Success, "Success", "Publication deleted successfully.");
            managingTrusteePublications = await AboutUsApiClient.GetManagingTrusteePublicationsAsync();
            if (isManagingTrusteePublicationEditMode && managingTrusteePublicationForm.Id == item.Id)
            {
                ResetManagingTrusteePublicationFormState();
            }
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
            }
            else
            {
                await AboutUsApiClient.CreateAboutUsDetailAsync(aboutUsDetailForm);
            }

            Notify(NotificationSeverity.Success, "Success", isAboutUsDetailEditMode ? "DIRI at a glance updated successfully." : "DIRI at a glance created successfully.");
            await LoadAllAsync();
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to save DIRI at a glance. {ex.Message}");
        }
    }

    private async Task DeleteCurrentAboutUsDetailAsync()
    {
        if (!isAboutUsDetailEditMode || aboutUsDetailForm.Id <= 0)
        {
            return;
        }

        if (!await ConfirmDeleteAsync($"Delete DIRI at a glance record #{aboutUsDetailForm.Id}?"))
        {
            return;
        }

        try
        {
            await AboutUsApiClient.DeleteAboutUsDetailAsync(aboutUsDetailForm.Id);
            Notify(NotificationSeverity.Success, "Success", "DIRI at a glance deleted successfully.");
            await LoadAllAsync();
        }
        catch (Exception ex)
        {
            Notify(NotificationSeverity.Error, "Failed", $"Unable to delete DIRI at a glance. {ex.Message}");
        }
    }

    private void ResetAboutUsDetailFormState() => SyncAboutUsDetailFormWithStoredRecord();

    private void SyncAboutUsDetailFormWithStoredRecord()
    {
        var storedAboutUsDetail = aboutUsDetails.OrderBy(x => x.Id).FirstOrDefault();
        if (storedAboutUsDetail is null)
        {
            aboutUsDetailForm = CreateAboutUsDetailForm();
            isAboutUsDetailEditMode = false;
            return;
        }

        aboutUsDetailForm = CloneAboutUsDetail(storedAboutUsDetail);
        isAboutUsDetailEditMode = true;
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

    private static FounderInfo CreateFounderInfoForm() => new() { Active = 1 };
    private static ManagingTrusteeInfo CreateManagingTrusteeInfoForm() => new() { Active = 1 };
    private static ManagingTrusteeDesignation CreateManagingTrusteeDesignationForm() => new() { Active = 1 };
    private static ManagingTrusteeArticle CreateManagingTrusteeArticleForm() => new() { Active = 1, PublishedDate = DateTime.Today };
    private static ManagingTrusteePublication CreateManagingTrusteePublicationForm() => new() { Active = 1, PublishedDate = DateTime.Today };
    private static AboutUsDetail CreateAboutUsDetailForm() => new() { Active = 1 };

    private sealed record PlannedSection(string Title, string Description);
}

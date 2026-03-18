using Shared.WebClientService;
using Domain.DBModels;
using Microsoft.AspNetCore.Components;

namespace DiriWebPortal.Pages.AboutUs
{
    public partial class ManagingTrustee
    {
        [Inject]
        private HomePageDataService _HomePageDataService { get; set; }
        [Inject]
        private ManagingTrusteeDataService _managingTrusteeDataService { get; set; }
        protected ManagingTrusteeInfo managingTrusteeInfo { get; set; }
        protected List<ManagingTrusteeDesignation> designation { get; set; }
        protected List<ManagingTrusteeArticle> articles { get; set; }
        protected List<ManagingTrusteePublication> publications { get; set; }
        protected async override Task OnInitializedAsync()
        {           
            managingTrusteeInfo = await _HomePageDataService.GetManagingTrusteeInfo();
            designation = await _managingTrusteeDataService.GetManagingTrusteeDesignation();
            articles = await _managingTrusteeDataService.GetManagingTrusteeArticles();
            publications = await _managingTrusteeDataService.GetManagingTrusteePublications();
        }
    }
}

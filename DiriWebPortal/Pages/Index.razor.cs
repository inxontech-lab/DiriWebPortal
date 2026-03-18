using Shared.WebClientService;
using Domain.DBModels;
using Microsoft.AspNetCore.Components;

namespace DiriWebPortal.Pages
{
    public partial class Index
    {
        [Inject]
        private HomePageDataService _HomePageDataService { get; set; }
        [Inject]
        private PublicationsPageDataService publicationsPageDataService { get; set; }
        protected NumericDashboard numericDashboard { get; set; }
        protected List<BannerText> bannerText { get; set; }
        protected FounderInfo founderInfo { get; set; }
        protected ManagingTrusteeInfo managingTrusteeInfo { get; set; }
        protected HighlightedEvent highlightedEvent { get; set; }
        protected AboutU aboutUs { get; set; }
        protected List<BookMaster> _lstBooks { get; set; }
        protected async override Task OnInitializedAsync()
        {            
            bannerText = await _HomePageDataService.GetHomePageBannerData();
            numericDashboard = await _HomePageDataService.GetNumericDashboardData();
            aboutUs = await _HomePageDataService.GetAboutUsSummary();
            founderInfo = await _HomePageDataService.GetFounderInfo();
            managingTrusteeInfo = await _HomePageDataService.GetManagingTrusteeInfo();
            highlightedEvent = await _HomePageDataService.GetHighlightedEvent();
            _lstBooks = await publicationsPageDataService.GetAllBooks(0);
        }
    }
}

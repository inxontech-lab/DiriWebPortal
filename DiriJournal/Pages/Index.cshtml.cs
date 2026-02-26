using DiriJournal.Services;
using Domain.DBModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace DiriJournal.Pages
{
    public class IndexModel : PageModel
    {
        private HomePageDataService _HomePageDataService { get; set; }
        private PublicationsPageDataService _publicationsPageDataService { get; set; }
        public NumericDashboard numericDashboard { get; set; }
        public List<BannerText> bannerText { get; set; }
        public FounderInfo founderInfo { get; set; }
        public ManagingTrusteeInfo managingTrusteeInfo { get; set; }
        public HighlightedEvent highlightedEvent { get; set; }
        public AboutU aboutUs { get; set; }
        public List<BookMaster> _lstBooks { get; set; }
        public string aboutUsLink = "/AboutDiri";

        public IndexModel(HomePageDataService HomePageDataService, PublicationsPageDataService PublicationsPageDataService)
        {
            _HomePageDataService = HomePageDataService;
            _publicationsPageDataService = PublicationsPageDataService;
        }

        public async Task OnGet()
        {
            await OnInitializedAsync();
        }

        protected async Task OnInitializedAsync()
        {
            bannerText = await _HomePageDataService.GetHomePageBannerData();
            numericDashboard = await _HomePageDataService.GetNumericDashboardData();
            aboutUs = await _HomePageDataService.GetAboutUsSummary();
            founderInfo = await _HomePageDataService.GetFounderInfo();
            managingTrusteeInfo = await _HomePageDataService.GetManagingTrusteeInfo();
            highlightedEvent = await _HomePageDataService.GetHighlightedEvent();
            _lstBooks = await _publicationsPageDataService.GetAllBooks(0);
        }
    }
}

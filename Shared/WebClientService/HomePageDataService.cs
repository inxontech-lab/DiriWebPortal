using Domain.DBModels;
using Domain.RespDTO.HomepageRespDTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Shared.WebClientService
{
    public class HomePageDataService
    {
        private ServiceClient serviceClient { get; set; } = new();
        private BannerTextDTO? BannerTextDTO { get; set; } = new();
        private List<BannerText>? BannerText { get; set; }
        private ContactU contactUs { get; set; }
        private OrganizationDataDTO organizationDataDTO { get; set; } = new();
        private NumericDashboard numericDashboard { get; set; } = new();

        private FounderInfoRespDTO FounderInfoRespDTO { get; set; }
        private AboutUsRespDTO aboutUsResp { get; set; }
        private AboutU aboutUs { get; set; }
        private ManagingTrusteeInfoRespDTO ManagingTrusteeRespDTO { get; set; }
        private HighlightedEventRespDTO highlightedEventResp { get; set; }
        private OurWebsiteRespDTO ourWebsiteRespDTO { get; set; } = new();
        private List<OurWebsite> ourWebsites { get; set; } = new();


        private IConfiguration _configuration;
        public HomePageDataService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<BannerText>> GetHomePageBannerData()
        {
            BannerText = new();
            string retrunString = null;
            retrunString = await serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"HomePage/GetHomePageBanner");
            BannerTextDTO = JsonConvert.DeserializeObject<BannerTextDTO>(retrunString);
            if (BannerTextDTO.RESPONSE_CODE.Equals("000"))
            {
                BannerText = BannerTextDTO.BannerData;
            }
            return BannerText;
        }

        public async Task<NumericDashboard> GetNumericDashboardData()
        {
            numericDashboard = new();
            string retrunString = null;
            retrunString = await serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"HomePage/GetNumericDashboard");
            numericDashboard = JsonConvert.DeserializeObject<NumericDashboard>(retrunString);
            return numericDashboard;
        }

        public async Task<AboutU> GetAboutUsSummary()
        {
            aboutUsResp = new();
            aboutUs = new();
            string retrunString = null;
            retrunString = await serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"HomePage/GeAboutUsSummary");
            aboutUsResp = JsonConvert.DeserializeObject<AboutUsRespDTO>(retrunString);
            if (aboutUsResp.RESPONSE_CODE.Equals("000"))
            {
                aboutUs = aboutUsResp.aboutUs;
            }            
            return aboutUs;
        }

        public async Task<FounderInfo> GetFounderInfo()
        {            
            FounderInfoRespDTO = new();
            string retrunString = null;
            retrunString = await serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"HomePage/GetFounderInfo");
            FounderInfoRespDTO = JsonConvert.DeserializeObject<FounderInfoRespDTO>(retrunString);
            return FounderInfoRespDTO.FounderInfo;
        }

        public async Task<ManagingTrusteeInfo> GetManagingTrusteeInfo()
        {
            ManagingTrusteeRespDTO = new();            
            string retrunString = null;
            retrunString = await serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"HomePage/GetManagingTrusteeInfo");
            ManagingTrusteeRespDTO = JsonConvert.DeserializeObject<ManagingTrusteeInfoRespDTO>(retrunString);
            return ManagingTrusteeRespDTO.ManagingTrusteeInfo;
        }

        public async Task<HighlightedEvent> GetHighlightedEvent()
        {
            highlightedEventResp = new();
            string retrunString = null;
            retrunString = await serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"HomePage/GetHighlightedEvent");
            highlightedEventResp = JsonConvert.DeserializeObject<HighlightedEventRespDTO>(retrunString);
            return highlightedEventResp.HighlightedEvent;
        }

        public async Task<ContactU> GetOrganizationalData()
        {
            contactUs = new();
            string retrunString = null;
            retrunString = await serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"HomePage/GetContactUsData");
            organizationDataDTO = JsonConvert.DeserializeObject<OrganizationDataDTO>(retrunString);
            if (organizationDataDTO.RESPONSE_CODE.Equals("000"))
            {
                contactUs = organizationDataDTO.ContactU;
            }
            return contactUs;
        }

        public async Task<List<OurWebsite>> GetOurWebsites()
        {
            ourWebsites = new();
            string retrunString = null;
            retrunString = await serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"OurWebsite/GetOurWebsites");
            ourWebsiteRespDTO = JsonConvert.DeserializeObject<OurWebsiteRespDTO>(retrunString);
            if (ourWebsiteRespDTO?.RESPONSE_CODE == "000" && ourWebsiteRespDTO.OurWebsites != null)
            {
                ourWebsites = ourWebsiteRespDTO.OurWebsites;
            }
            return ourWebsites;
        }
    }
}

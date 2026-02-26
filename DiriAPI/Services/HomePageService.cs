using DataAccess.Core;
using Domain.DBModels;
using Domain.RespDTO.HomepageRespDTO;
using System.Diagnostics.Contracts;

namespace DiriAPI.Services
{
    public class HomePageService
    {
        private DiriWebPortalContext _diriWebPortalContext;
        public HomePage homePage { get; set; }
        public List<BannerText> bannerText { get; set; } = new();
        public HomePageDTO homePageDto { get; set; } = new();
        public BannerTextDTO bannerDataDto { get; set; } = new();
        private NumericDashboard dashboard { get; set; } = new();
        private ContactU contactU { get; set; } = new();
        private OrganizationDataDTO organizationDataDTO { get; set; } = new();

        private AboutUsRespDTO aboutUsResp { get; set; } = new();
        private AboutU aboutUs{ get; set; } = new();

        private FounderInfoRespDTO founderDto { get; set; } = new();
        private FounderInfo founder { get; set; } = new();
        private ManagingTrusteeInfoRespDTO ManagingTrusteeDto { get; set; } = new();
        private ManagingTrusteeInfo ManagingTrustee { get; set; } = new();

        private HighlightedEventRespDTO HighlightedEventRespDTO { get; set; } = new();
        private HighlightedEvent highlightedEvent { get; set; } = new();
        public HomePageService(DiriWebPortalContext diriWebPortalContext)
        {
            _diriWebPortalContext = diriWebPortalContext;
        }     

        public NumericDashboard GetNumericDashboard()
        {
            dashboard = new();
            try
            {
                dashboard = _diriWebPortalContext.NumericDashboards.Where(x => x.Active == 1).FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
            return dashboard;
        }

        public BannerTextDTO GetHomePageBanner()
        {
            bannerText = new();
            bannerDataDto = new();
            try
            {
                bannerText = _diriWebPortalContext.BannerTexts.Where(x => x.Active == 1).ToList();
                if (bannerText != null)
                {
                    bannerDataDto.RESPONSE_CODE = ConfigClass.SUCCESS;
                    bannerDataDto.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    bannerDataDto.BannerData = bannerText;
                }
                else
                {
                    bannerDataDto.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    bannerDataDto.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    bannerDataDto.BannerData = null;
                }
            }
            catch (Exception ex)
            {
                bannerDataDto.RESPONSE_CODE = ConfigClass.ERROR;
                bannerDataDto.RESPONSE_DESCRPTION = ex.ToString();
                bannerDataDto.BannerData = null;
            }
            return bannerDataDto;
        }

        public OrganizationDataDTO GetOrganizationData()
        {
            organizationDataDTO = new OrganizationDataDTO();
            try
            {
                contactU = _diriWebPortalContext.ContactUs.FirstOrDefault();
                if (contactU != null)
                {
                    organizationDataDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    organizationDataDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    organizationDataDTO.ContactU = contactU;
                }
                else
                {
                    organizationDataDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    organizationDataDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    organizationDataDTO.ContactU = null;
                }
            }
            catch (Exception ex)
            {
                organizationDataDTO.RESPONSE_CODE = ConfigClass.ERROR;
                organizationDataDTO.RESPONSE_DESCRPTION = ex.ToString();
                organizationDataDTO.ContactU = null;
            }
            return organizationDataDTO;
        }
        public AboutUsRespDTO GeAboutUsSummary()
        {
            aboutUsResp = new AboutUsRespDTO();
            try
            {
                aboutUs = _diriWebPortalContext.AboutUs.FirstOrDefault();
                if (aboutUs != null)
                {
                    aboutUsResp.RESPONSE_CODE = ConfigClass.SUCCESS;
                    aboutUsResp.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    aboutUsResp.aboutUs = aboutUs;
                }
                else
                {
                    aboutUsResp.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    aboutUsResp.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    aboutUsResp.aboutUs = null;
                }
            }
            catch (Exception ex)
            {
                aboutUsResp.RESPONSE_CODE = ConfigClass.ERROR;
                aboutUsResp.RESPONSE_DESCRPTION = ex.ToString();
                aboutUsResp.aboutUs = null;
            }
            return aboutUsResp;
        }

        public FounderInfoRespDTO GetFounderInfo()
        {
            founderDto = new();
            founder = new();
            try
            {
                founder = _diriWebPortalContext.FounderInfos.FirstOrDefault();
                if (founder != null)
                {
                    founderDto.RESPONSE_CODE = ConfigClass.SUCCESS;
                    founderDto.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    founderDto.FounderInfo = founder;
                }
                else
                {
                    founderDto.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    founderDto.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    founderDto.FounderInfo = null;
                }
            }
            catch (Exception ex)
            {
                founderDto.RESPONSE_CODE = ConfigClass.ERROR;
                founderDto.RESPONSE_DESCRPTION = ex.ToString();
                founderDto.FounderInfo = null;
            }
            return founderDto;
        }

        public ManagingTrusteeInfoRespDTO GetManagingTrusteeInfo()
        {
            ManagingTrusteeDto = new();
            ManagingTrustee = new();
            try
            {
                ManagingTrustee = _diriWebPortalContext.ManagingTrusteeInfos.FirstOrDefault();
                if (ManagingTrustee != null)
                {
                    ManagingTrusteeDto.RESPONSE_CODE = ConfigClass.SUCCESS;
                    ManagingTrusteeDto.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    ManagingTrusteeDto.ManagingTrusteeInfo = ManagingTrustee;
                }
                else
                {
                    ManagingTrusteeDto.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    ManagingTrusteeDto.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    ManagingTrusteeDto.ManagingTrusteeInfo = null;
                }
            }
            catch (Exception ex)
            {
                ManagingTrusteeDto.RESPONSE_CODE = ConfigClass.ERROR;
                ManagingTrusteeDto.RESPONSE_DESCRPTION = ex.ToString();
                ManagingTrusteeDto.ManagingTrusteeInfo = null;
            }
            return ManagingTrusteeDto;
        }

        public HighlightedEventRespDTO GetHighlightedEvent()
        {
            HighlightedEventRespDTO = new();
            highlightedEvent = new();
            try
            {
                highlightedEvent = _diriWebPortalContext.HighlightedEvents.Where(x => x.Active == 1).FirstOrDefault();
                if (contactU != null)
                {
                    HighlightedEventRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    HighlightedEventRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    HighlightedEventRespDTO.HighlightedEvent = highlightedEvent;
                }
                else
                {
                    HighlightedEventRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    HighlightedEventRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    HighlightedEventRespDTO.HighlightedEvent = null;
                }
            }
            catch (Exception ex)
            {
                HighlightedEventRespDTO.RESPONSE_CODE = ConfigClass.ERROR;
                HighlightedEventRespDTO.RESPONSE_DESCRPTION = ex.ToString();
                HighlightedEventRespDTO.HighlightedEvent = null;
            }
            return HighlightedEventRespDTO;
        }
    }
}

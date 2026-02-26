using DataAccess.Core;
using Domain.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using DiriAPI.Services;
using Domain.RespDTO.HomepageRespDTO;

namespace DiriAPI.Controller
{
    [ApiController]
    public class HomePageController : ControllerBase
    {
        private HomePageService _homePageService;
        public HomePageController(HomePageService homePageService)
        {
            _homePageService = homePageService;
        }

        [Route("api/[controller]/GetHomePageBanner")]
        [HttpGet]
        public BannerTextDTO GetHomePageBanner()
        {
            return _homePageService.GetHomePageBanner();
        }

        [Route("api/[controller]/GetNumericDashboard")]
        [HttpGet]
        public NumericDashboard GetNumericDashboard()
        {
            return _homePageService.GetNumericDashboard();
        }

        [Route("api/[controller]/GetContactUsData")]
        [HttpGet]
        public OrganizationDataDTO GetContactUsData()
        {
            return _homePageService.GetOrganizationData();
        }

        [Route("api/[controller]/GeAboutUsSummary")]
        [HttpGet]
        public AboutUsRespDTO GeAboutUsSummary()
        {
            return _homePageService.GeAboutUsSummary();
        }

        [Route("api/[controller]/GetFounderInfo")]
        [HttpGet]
        public FounderInfoRespDTO GetFounderInfo()
        {
            return _homePageService.GetFounderInfo();
        }

        [Route("api/[controller]/GetManagingTrusteeInfo")]
        [HttpGet]
        public ManagingTrusteeInfoRespDTO GetManagingTrusteeInfo()
        {
            return _homePageService.GetManagingTrusteeInfo();
        }

        [Route("api/[controller]/GetHighlightedEvent")]
        [HttpGet]
        public HighlightedEventRespDTO GetHighlightedEvent()
        {
            return _homePageService.GetHighlightedEvent();
        }        
    }
}

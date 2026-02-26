using DiriAPI.Services;
using Domain.RespDTO.AboutUsPageRespDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiriAPI.Controller
{    
    [ApiController]
    public class AboutUsController : ControllerBase
    {
        private AboutUsPageService _aboutUsPageService;
        public AboutUsController(AboutUsPageService aboutUsPageService)
        {
            _aboutUsPageService = aboutUsPageService;
        }

        [Route("api/[controller]/GetAboutUsDetails")]
        [HttpGet]
        public AboutUsDetailsRespDTO GetAboutUsDetails()
        {
            return _aboutUsPageService.GetAboutUsDetails();
        }
    }
}

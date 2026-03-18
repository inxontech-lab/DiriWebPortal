using DiriAPI.Services;
using Domain.RespDTO.HomepageRespDTO;
using Microsoft.AspNetCore.Mvc;

namespace DiriAPI.Controller
{
    [ApiController]
    public class OurWebsiteController : ControllerBase
    {
        private readonly OurWebsiteService _ourWebsiteService;

        public OurWebsiteController(OurWebsiteService ourWebsiteService)
        {
            _ourWebsiteService = ourWebsiteService;
        }

        [Route("api/[controller]/GetOurWebsites")]
        [HttpGet]
        public OurWebsiteRespDTO GetOurWebsites()
        {
            return _ourWebsiteService.GetOurWebsites();
        }
    }
}

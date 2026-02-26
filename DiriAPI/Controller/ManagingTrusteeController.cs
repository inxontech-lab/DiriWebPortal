using DiriAPI.Services;
using Domain.RespDTO.AboutUsPageRespDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiriAPI.Controller
{    
    [ApiController]
    public class ManagingTrusteeController : ControllerBase
    {
        private ManagingTrusteeDataService _service;
        public ManagingTrusteeController(ManagingTrusteeDataService service)
        {
            _service = service;
        }

        [Route("api/[controller]/GetManagingTrusteeDesignation")]
        [HttpGet]
        public ManagingTusteeDesigRespDTO GetManagingTrusteeDesignation()
        {
            return _service.GetManagingTrusteeDesignation();
        }

        [Route("api/[controller]/GetManagingTrusteeArticles")]
        [HttpGet]
        public ManagingTrusteeArticlesRespDTO GetManagingTrusteeArticles()
        {
            return _service.GetManagingTrusteeArticles();
        }

        [Route("api/[controller]/GetManagingTrusteePublications")]
        [HttpGet]
        public ManagingTrusteePubRespDTO GetManagingTrusteePublications()
        {
            return _service.GetManagingTrusteePublications();
        }
    }
}

using DiriAPI.Services;
using Domain.RespDTO.HomepageRespDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiriAPI.Controller
{
    [ApiController]
    public class MasterInfoController : ControllerBase
    {
        private MasterInfoService _service;
        public MasterInfoController(MasterInfoService service)
        {
            _service = service;
        }

        [Route("api/[controller]/GetFounderInfo")]
        [HttpGet]
        public FounderInfoRespDTO GetFounderInfo()
        {
            return _service.GetFounderInfo();
        }

        [Route("api/[controller]/GetManagingTrusteeInfo")]
        [HttpGet]
        public ManagingTrusteeInfoRespDTO GetManagingTrusteeInfo()
        {
            return _service.GetManagingTrusteeInfo();
        }
    }
}

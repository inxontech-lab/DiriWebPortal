using DiriAPI.Services.ConferenceSchemaService;
using Domain.RespDTO.ConferenceSchemaRespDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiriAPI.Controller.ConferenceSchema
{   
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private ConferencePlatformService _service;
        public PlatformController(ConferencePlatformService service)
        {
            _service = service;
        }
        [Route("api/[controller]/GetAllPlatformList")]
        [HttpGet]
        public ConferencePlatformRespDTO GetAllPlatformList()
        {
            return _service.GetAllPlatformList();
        }
    }
}

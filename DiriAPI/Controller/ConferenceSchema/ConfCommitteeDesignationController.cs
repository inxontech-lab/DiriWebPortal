using DiriAPI.Services.ConferenceSchemaService;
using Domain.RespDTO.ConferenceSchemaRespDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiriAPI.Controller.ConferenceSchema
{    
    [ApiController]
    public class ConfCommitteeDesignationController : ControllerBase
    {
        private ConfCommitteeDesignationService _service;
        public ConfCommitteeDesignationController(ConfCommitteeDesignationService service)
        {
            _service = service;
        }

        [Route("api/[controller]/GetAllConfCommDesignationList")]
        [HttpGet]
        public ConfCommitteeDesignationRespDTO GetAllConfCommDesignationList()
        {
            return _service.GetAllConfCommDesignationList();
        }
    }
}

using DiriAPI.Services.MasterSchemaServices;
using Domain.RespDTO.MasterSchemaRespDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiriAPI.Controller.MasterSchema
{    
    [ApiController]
    public class execCommitteeDesignationController : ControllerBase
    {
        private ExecCommitteeDesignationService _service;
        public execCommitteeDesignationController(ExecCommitteeDesignationService service)
        {
            _service = service;
        }
        [Route("api/[controller]/GetAllExecDesignationList")]
        [HttpGet]
        public ExecutiveCommitteeDesignationRespDTO GetAllExecDesignationList()
        {
            return _service.GetAllExecDesignationList();
        }
    }
}

using DiriAPI.Services.MasterSchemaServices;
using Domain.RespDTO.MasterSchemaRespDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiriAPI.Controller.MasterSchema
{    
    [ApiController]
    public class OccDesignationController : ControllerBase
    {
        private OccupationalDesignationService _service;
        public OccDesignationController(OccupationalDesignationService service)
        {
            _service = service;
        }

        [Route("api/[controller]/GetAllOccDesignationList")]
        [HttpGet]
        public OccupationaleDesignationRespDTO GetAllOccDesignationList()
        {
            return _service.GetAllOccDesignationList();
        }
    }
}

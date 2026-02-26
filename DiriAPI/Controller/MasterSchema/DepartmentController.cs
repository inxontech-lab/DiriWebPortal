using DiriAPI.Services.MasterSchemaServices;
using Domain.RespDTO.MasterSchemaRespDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiriAPI.Controller.MasterSchema
{    
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private DepartmentService _service;
        public DepartmentController(DepartmentService service)
        {
            _service = service;
        }

        [Route("api/[controller]/GetAllDepartmentList")]
        [HttpGet]
        public DepartmentRespDTO GetAllDepartmentList()
        {
            return _service.GetAllDepartmentList();
        }
    }
}

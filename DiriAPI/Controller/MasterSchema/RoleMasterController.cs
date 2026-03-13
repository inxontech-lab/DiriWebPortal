using DiriAPI.Services.MasterSchemaServices;
using Domain.DBModels;
using Domain.RespDTO.MasterSchemaRespDTO;
using Microsoft.AspNetCore.Mvc;

namespace DiriAPI.Controller.MasterSchema
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleMasterController : ControllerBase
    {
        private readonly RoleMasterService _service;

        public RoleMasterController(RoleMasterService service)
        {
            _service = service;
        }

        [HttpGet]
        public RoleMasterRespDTO GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        public RoleMasterRespDTO GetById(int id) => _service.GetById(id);

        [HttpPost]
        public RoleMasterRespDTO Create([FromBody] RoleMaster role) => _service.Create(role);

        [HttpPut("{id}")]
        public RoleMasterRespDTO Update(int id, [FromBody] RoleMaster role) => _service.Update(id, role);

        [HttpDelete("{id}")]
        public RoleMasterRespDTO Delete(int id) => _service.Delete(id);
    }
}

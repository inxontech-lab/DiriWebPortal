using DiriAPI.Services.MasterSchemaServices;
using Domain.DBModels;
using Domain.RespDTO.MasterSchemaRespDTO;
using Microsoft.AspNetCore.Mvc;

namespace DiriAPI.Controller.MasterSchema
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRolesController : ControllerBase
    {
        private readonly UserRolesService _service;

        public UserRolesController(UserRolesService service)
        {
            _service = service;
        }

        [HttpGet]
        public UserRoleRespDTO GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        public UserRoleRespDTO GetById(int id) => _service.GetById(id);

        [HttpPost]
        public UserRoleRespDTO Create([FromBody] UserRole userRole) => _service.Create(userRole);

        [HttpPut("{id}")]
        public UserRoleRespDTO Update(int id, [FromBody] UserRole userRole) => _service.Update(id, userRole);

        [HttpDelete("{id}")]
        public UserRoleRespDTO Delete(int id) => _service.Delete(id);
    }
}

using DiriAPI.Services.MasterSchemaServices;
using Domain.DTO.MasterSchemaDTO;
using Domain.RespDTO.MasterSchemaRespDTO;
using Microsoft.AspNetCore.Mvc;

namespace DiriAPI.Controller.MasterSchema
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserWithRolesController : ControllerBase
    {
        private readonly UserWithRolesService _service;

        public UserWithRolesController(UserWithRolesService service)
        {
            _service = service;
        }

        [HttpGet]
        public UserWithRolesRespDTO GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        public UserWithRolesRespDTO GetById(int id) => _service.GetById(id);

        [HttpPost]
        public UserWithRolesRespDTO Create([FromBody] UserWithRolesDTO request) => _service.Create(request);

        [HttpPut("{id}")]
        public UserWithRolesRespDTO Update(int id, [FromBody] UserWithRolesDTO request) => _service.Update(id, request);

        [HttpDelete("{id}")]
        public UserWithRolesRespDTO Delete(int id) => _service.Delete(id);
    }
}

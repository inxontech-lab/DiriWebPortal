using DiriAPI.Services.MasterSchemaServices;
using Domain.DBModels;
using Domain.RespDTO.MasterSchemaRespDTO;
using Microsoft.AspNetCore.Mvc;

namespace DiriAPI.Controller.MasterSchema
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _service;

        public UsersController(UsersService service)
        {
            _service = service;
        }

        [HttpGet]
        public UserRespDTO GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        public UserRespDTO GetById(int id) => _service.GetById(id);

        [HttpPost]
        public UserRespDTO Create([FromBody] User user) => _service.Create(user);

        [HttpPut("{id}")]
        public UserRespDTO Update(int id, [FromBody] User user) => _service.Update(id, user);

        [HttpDelete("{id}")]
        public UserRespDTO Delete(int id) => _service.Delete(id);
    }
}

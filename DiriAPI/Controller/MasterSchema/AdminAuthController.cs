using DiriAPI.Services.MasterSchemaServices;
using Domain.DTO.Auth;
using Domain.RespDTO.Auth;
using Microsoft.AspNetCore.Mvc;

namespace DiriAPI.Controller.MasterSchema;

[ApiController]
[Route("api/[controller]")]
public class AdminAuthController : ControllerBase
{
    private readonly AdminAuthService _service;

    public AdminAuthController(AdminAuthService service)
    {
        _service = service;
    }

    [HttpPost("login")]
    public ActionResult<AdminLoginRespDTO> Login([FromBody] AdminLoginRequestDTO request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new AdminLoginRespDTO
            {
                RESPONSE_CODE = "400",
                RESPONSE_DESCRPTION = "Invalid login request."
            });
        }

        var response = _service.Login(request);

        return response.RESPONSE_CODE == DataAccess.Core.ConfigClass.SUCCESS ? Ok(response) : Unauthorized(response);
    }
}

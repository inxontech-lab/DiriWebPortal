using Domain.DTO.Auth;

namespace Domain.RespDTO.Auth;

public class AdminLoginRespDTO
{
    public string RESPONSE_CODE { get; set; } = string.Empty;
    public string RESPONSE_DESCRPTION { get; set; } = string.Empty;
    public AdminSessionDTO? data { get; set; }
}

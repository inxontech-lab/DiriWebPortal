using Domain.DTO.MasterSchemaDTO;

namespace Domain.RespDTO.MasterSchemaRespDTO
{
    public class UserWithRolesRespDTO
    {
        public string RESPONSE_CODE { get; set; } = string.Empty;
        public string RESPONSE_DESCRPTION { get; set; } = string.Empty;
        public UserWithRolesDTO? data { get; set; }
        public List<UserWithRolesDTO>? lstData { get; set; }
    }
}

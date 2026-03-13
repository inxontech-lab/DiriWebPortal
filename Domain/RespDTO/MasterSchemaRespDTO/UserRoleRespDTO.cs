using Domain.DBModels;

namespace Domain.RespDTO.MasterSchemaRespDTO
{
    public class UserRoleRespDTO
    {
        public string RESPONSE_CODE { get; set; } = string.Empty;
        public string RESPONSE_DESCRPTION { get; set; } = string.Empty;
        public UserRole? data { get; set; }
        public List<UserRole>? lstData { get; set; }
    }
}

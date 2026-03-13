using Domain.DBModels;

namespace Domain.RespDTO.MasterSchemaRespDTO
{
    public class UserRespDTO
    {
        public string RESPONSE_CODE { get; set; } = string.Empty;
        public string RESPONSE_DESCRPTION { get; set; } = string.Empty;
        public User? data { get; set; }
        public List<User>? lstData { get; set; }
    }
}

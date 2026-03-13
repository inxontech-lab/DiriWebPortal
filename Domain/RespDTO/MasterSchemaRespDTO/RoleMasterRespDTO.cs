using Domain.DBModels;

namespace Domain.RespDTO.MasterSchemaRespDTO
{
    public class RoleMasterRespDTO
    {
        public string RESPONSE_CODE { get; set; } = string.Empty;
        public string RESPONSE_DESCRPTION { get; set; } = string.Empty;
        public RoleMaster? data { get; set; }
        public List<RoleMaster>? lstData { get; set; }
    }
}

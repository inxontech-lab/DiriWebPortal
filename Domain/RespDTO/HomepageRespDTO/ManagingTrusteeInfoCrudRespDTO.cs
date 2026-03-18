using Domain.DBModels;

namespace Domain.RespDTO.HomepageRespDTO
{
    public class ManagingTrusteeInfoCrudRespDTO
    {
        public string RESPONSE_CODE { get; set; } = string.Empty;
        public string RESPONSE_DESCRPTION { get; set; } = string.Empty;
        public ManagingTrusteeInfo? data { get; set; }
        public List<ManagingTrusteeInfo>? lstData { get; set; }
    }
}

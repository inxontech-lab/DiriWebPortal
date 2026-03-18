using Domain.DBModels;

namespace Domain.RespDTO.HomepageRespDTO
{
    public class FounderInfoCrudRespDTO
    {
        public string RESPONSE_CODE { get; set; } = string.Empty;
        public string RESPONSE_DESCRPTION { get; set; } = string.Empty;
        public FounderInfo? data { get; set; }
        public List<FounderInfo>? lstData { get; set; }
    }
}

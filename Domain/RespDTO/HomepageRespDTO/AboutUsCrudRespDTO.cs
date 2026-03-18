using Domain.DBModels;

namespace Domain.RespDTO.HomepageRespDTO
{
    public class AboutUsCrudRespDTO
    {
        public string RESPONSE_CODE { get; set; } = string.Empty;
        public string RESPONSE_DESCRPTION { get; set; } = string.Empty;
        public AboutU? data { get; set; }
        public List<AboutU>? lstData { get; set; }
    }
}

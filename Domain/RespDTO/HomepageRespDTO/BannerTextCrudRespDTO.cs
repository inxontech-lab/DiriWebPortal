using Domain.DBModels;

namespace Domain.RespDTO.HomepageRespDTO
{
    public class BannerTextCrudRespDTO
    {
        public string RESPONSE_CODE { get; set; } = string.Empty;
        public string RESPONSE_DESCRPTION { get; set; } = string.Empty;
        public BannerText? data { get; set; }
        public List<BannerText>? lstData { get; set; }
    }
}

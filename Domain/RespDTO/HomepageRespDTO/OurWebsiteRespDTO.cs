using Domain.DBModels;

namespace Domain.RespDTO.HomepageRespDTO
{
    public class OurWebsiteRespDTO
    {
        public string RESPONSE_CODE { get; set; }
        public string RESPONSE_DESCRPTION { get; set; }
        public List<OurWebsite>? OurWebsites { get; set; }
    }
}

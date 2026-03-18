using Domain.DBModels;

namespace Domain.RespDTO.AboutUsPageRespDTO;

public class ManagingTrusteeArticleCrudRespDTO
{
    public string RESPONSE_CODE { get; set; } = string.Empty;
    public string RESPONSE_DESCRPTION { get; set; } = string.Empty;
    public ManagingTrusteeArticle? data { get; set; }
    public List<ManagingTrusteeArticle>? lstData { get; set; }
}

using Domain.DBModels;

namespace Domain.RespDTO.AboutUsPageRespDTO;

public class ManagingTrusteePublicationCrudRespDTO
{
    public string RESPONSE_CODE { get; set; } = string.Empty;
    public string RESPONSE_DESCRPTION { get; set; } = string.Empty;
    public ManagingTrusteePublication? data { get; set; }
    public List<ManagingTrusteePublication>? lstData { get; set; }
}

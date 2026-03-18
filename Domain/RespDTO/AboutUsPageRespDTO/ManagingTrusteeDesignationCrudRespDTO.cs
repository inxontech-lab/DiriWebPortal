using Domain.DBModels;

namespace Domain.RespDTO.AboutUsPageRespDTO;

public class ManagingTrusteeDesignationCrudRespDTO
{
    public string RESPONSE_CODE { get; set; } = string.Empty;
    public string RESPONSE_DESCRPTION { get; set; } = string.Empty;
    public ManagingTrusteeDesignation? data { get; set; }
    public List<ManagingTrusteeDesignation>? lstData { get; set; }
}

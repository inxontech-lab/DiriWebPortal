using Domain.DBModels;

namespace Domain.RespDTO.AboutUsPageRespDTO;

public class AboutUsDetailsCrudRespDTO
{
    public string RESPONSE_CODE { get; set; } = string.Empty;
    public string RESPONSE_DESCRPTION { get; set; } = string.Empty;
    public AboutUsDetail? data { get; set; }
    public List<AboutUsDetail>? lstData { get; set; }
}

using Domain.DBModels;

namespace Domain.RespDTO.HomepageRespDTO
{
    public class NumericDashboardCrudRespDTO
    {
        public string RESPONSE_CODE { get; set; } = string.Empty;
        public string RESPONSE_DESCRPTION { get; set; } = string.Empty;
        public NumericDashboard? data { get; set; }
        public List<NumericDashboard>? lstData { get; set; }
    }
}

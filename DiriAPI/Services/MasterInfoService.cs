using DataAccess.Core;
using Domain.DBModels;
using Domain.RespDTO.HomepageRespDTO;
using System.Diagnostics.Contracts;

namespace DiriAPI.Services
{
    public class MasterInfoService
    {
        private DiriWebPortalContext _diriWebPortalContext;
        private FounderInfoRespDTO Resp;
        private FounderInfo FounderInfo;

        private ManagingTrusteeInfoRespDTO ManagingResp;
        private ManagingTrusteeInfo ManagingTrusteeInfo;
        

        public MasterInfoService(DiriWebPortalContext context)
        {
            _diriWebPortalContext = context;
        }

        public FounderInfoRespDTO GetFounderInfo()
        {
            Resp = new();
            FounderInfo = new();
            try {
                FounderInfo = _diriWebPortalContext.FounderInfos.FirstOrDefault();
                if (FounderInfo != null)
                {
                    Resp.RESPONSE_CODE = ConfigClass.SUCCESS;
                    Resp.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    Resp.FounderInfo = FounderInfo;
                }
                else
                {
                    Resp.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    Resp.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    Resp.FounderInfo = null;
                }
            }
            catch(Exception ex)
            {
                Resp.RESPONSE_CODE = ConfigClass.ERROR;
                Resp.RESPONSE_DESCRPTION = ex.ToString();
                Resp.FounderInfo = null;
            }
            return Resp;
        }

        public ManagingTrusteeInfoRespDTO GetManagingTrusteeInfo()
        {
            ManagingResp = new();
            ManagingTrusteeInfo = new();
            try
            {
                ManagingTrusteeInfo = _diriWebPortalContext.ManagingTrusteeInfos.FirstOrDefault();
                if (ManagingTrusteeInfo != null)
                {
                    ManagingResp.RESPONSE_CODE = ConfigClass.SUCCESS;
                    ManagingResp.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    ManagingResp.ManagingTrusteeInfo = ManagingTrusteeInfo;
                }
                else
                {
                    ManagingResp.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    ManagingResp.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    ManagingResp.ManagingTrusteeInfo = null;
                }
            }
            catch (Exception ex)
            {
                ManagingResp.RESPONSE_CODE = ConfigClass.ERROR;
                Resp.RESPONSE_DESCRPTION = ex.ToString();
                ManagingResp.ManagingTrusteeInfo = null;
            }
            return ManagingResp;
        }
    }
}

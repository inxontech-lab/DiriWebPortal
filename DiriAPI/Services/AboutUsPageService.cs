using DataAccess.Core;
using Domain.DBModels;
using Domain.RespDTO.AboutUsPageRespDTO;
using Domain.RespDTO.HomepageRespDTO;
using System.Diagnostics.Contracts;

namespace DiriAPI.Services
{
    public class AboutUsPageService
    {
        private DiriWebPortalContext _diriWebPortalContext;
        private AboutUsDetail AboutUsDetail;
        private AboutUsDetailsRespDTO Resp;
        public AboutUsPageService(DiriWebPortalContext diriWebPortalContext)
        {
            _diriWebPortalContext = diriWebPortalContext;
        }

        public AboutUsDetailsRespDTO GetAboutUsDetails()
        {
            AboutUsDetail = new();
            Resp = new();
            try
            {
                AboutUsDetail = _diriWebPortalContext.AboutUsDetails.Where(x => x.Active == 1).FirstOrDefault();
                if (AboutUsDetail != null)
                {
                    Resp.RESPONSE_CODE = ConfigClass.SUCCESS;
                    Resp.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    Resp.AboutUsDetails = AboutUsDetail;
                }
                else
                {
                    Resp.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    Resp.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    Resp.AboutUsDetails = null;
                }
            }
            catch (Exception ex)
            {
                Resp.RESPONSE_CODE = ConfigClass.ERROR;
                Resp.RESPONSE_DESCRPTION = ex.ToString();
                Resp.AboutUsDetails = null;
            }
            return Resp;
        }
    }
}

using DataAccess.Core;
using Domain.DBModels;
using Domain.RespDTO.HomepageRespDTO;

namespace DiriAPI.Services
{
    public class OurWebsiteService
    {
        private readonly DiriWebPortalContext _diriWebPortalContext;

        public OurWebsiteService(DiriWebPortalContext diriWebPortalContext)
        {
            _diriWebPortalContext = diriWebPortalContext;
        }

        public OurWebsiteRespDTO GetOurWebsites()
        {
            var response = new OurWebsiteRespDTO();

            try
            {
                var websites = _diriWebPortalContext.OurWebsites
                    .Where(x => x.Active == 1)
                    .ToList();

                if (websites.Any())
                {
                    response.RESPONSE_CODE = ConfigClass.SUCCESS;
                    response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    response.OurWebsites = websites;
                }
                else
                {
                    response.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    response.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    response.OurWebsites = null;
                }
            }
            catch (Exception ex)
            {
                response.RESPONSE_CODE = ConfigClass.ERROR;
                response.RESPONSE_DESCRPTION = ex.ToString();
                response.OurWebsites = null;
            }

            return response;
        }
    }
}

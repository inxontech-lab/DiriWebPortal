using DataAccess.Core;
using Domain.DBModels;
using Domain.RespDTO.HomepageRespDTO;
using Domain.RespDTO.MasterSchemaRespDTO;

namespace DiriAPI.Services.MasterSchemaServices
{
    public class CountryServices
    {
        private DiriWebPortalContext _diriWebPortalContext;
        private CountryRespDTO countryRespDTO;
        private List<Country> lstCountry;
        public CountryServices(DiriWebPortalContext diriWebPortalContext)
        {
            _diriWebPortalContext = diriWebPortalContext;
        }
        public CountryRespDTO GetAllCountryList()
        {
            countryRespDTO = new();
            lstCountry = new();
            try
            {
                lstCountry = _diriWebPortalContext.Countries.Where(x => x.Active == 1).ToList();
                if (lstCountry != null)
                {
                    countryRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    countryRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    countryRespDTO.lstData = lstCountry;
                }
                else
                {
                    countryRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    countryRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    countryRespDTO.lstData = null;
                }
            }
            catch (Exception ex)
            {
                countryRespDTO.RESPONSE_CODE = ConfigClass.ERROR;
                countryRespDTO.RESPONSE_DESCRPTION = ex.ToString();
                countryRespDTO.lstData = null;
            }
            return countryRespDTO;
        }
    }
}

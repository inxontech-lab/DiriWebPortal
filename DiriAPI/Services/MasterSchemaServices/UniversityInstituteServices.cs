using DataAccess.Core;
using Domain.DBModels;
using Domain.RespDTO.MasterSchemaRespDTO;

namespace DiriAPI.Services.MasterSchemaServices
{
    public class UniversityInstituteServices
    {
        private DiriWebPortalContext _diriWebPortalContext;
        private UniversityInstituteRespDTO respDTO;
        private List<UniversityInstitute> lstUniversities;
        public UniversityInstituteServices(DiriWebPortalContext diriWebPortalContext)
        {
            _diriWebPortalContext = diriWebPortalContext;
        }

        public UniversityInstituteRespDTO GetAllUniversityInstitute()
        {
            respDTO = new();
            lstUniversities = new();
            try
            {
                lstUniversities = _diriWebPortalContext.UniversityInstitutes.Where(x => x.Active == 1).ToList();
                if (lstUniversities != null)
                {
                    respDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    respDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    respDTO.lstData = lstUniversities;
                }
                else
                {
                    respDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    respDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    respDTO.lstData = null;
                }
            }
            catch (Exception ex)
            {
                respDTO.RESPONSE_CODE = ConfigClass.ERROR;
                respDTO.RESPONSE_DESCRPTION = ex.ToString();
                respDTO.lstData = null;
            }
            return respDTO;
        }

        public UniversityInstituteRespDTO GetAllUniversityByCountry(string country)
        {
            respDTO = new();
            lstUniversities = new();
            try
            {
                lstUniversities = _diriWebPortalContext.UniversityInstitutes.Where(x => x.Active == 1 && x.CountryId == Convert.ToInt32(country)).ToList();
                if (lstUniversities != null)
                {
                    respDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    respDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    respDTO.lstData = lstUniversities;
                }
                else
                {
                    respDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    respDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    respDTO.lstData = null;
                }
            }
            catch (Exception ex)
            {
                respDTO.RESPONSE_CODE = ConfigClass.ERROR;
                respDTO.RESPONSE_DESCRPTION = ex.ToString();
                respDTO.lstData = null;
            }
            return respDTO;
        }
    }
}

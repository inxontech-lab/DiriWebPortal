using DataAccess.Core;
using Domain.DBModels;
using Domain.RespDTO.ConferenceSchemaRespDTO;
using Domain.RespDTO.MasterSchemaRespDTO;

namespace DiriAPI.Services.ConferenceSchemaService
{
    public class ConferencePlatformService
    {
        private DiriWebPortalContext _diriWebPortalContext;
        private ConferencePlatformRespDTO _respDTO;
        private List<PlatformMaster> _lstPlatform;
        public ConferencePlatformService(DiriWebPortalContext diriWebPortalContext)
        {
            _diriWebPortalContext = diriWebPortalContext;
        }

        public ConferencePlatformRespDTO GetAllPlatformList()
        {
            _respDTO = new();
            _lstPlatform = new();
            try
            {
                _lstPlatform = _diriWebPortalContext.PlatformMasters.Where(x => x.Active == 1).ToList();
                if (_lstPlatform != null)
                {
                    _respDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _respDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _respDTO.lstData = _lstPlatform;
                }
                else
                {
                    _respDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _respDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _respDTO.lstData = null;
                }
            }
            catch (Exception ex)
            {
                _respDTO.RESPONSE_CODE = ConfigClass.ERROR;
                _respDTO.RESPONSE_DESCRPTION = ex.ToString();
                _respDTO.lstData = null;
            }
            return _respDTO;
        }
    }
}

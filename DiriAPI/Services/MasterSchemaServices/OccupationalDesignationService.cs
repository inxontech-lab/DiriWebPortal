using DataAccess.Core;
using Domain.DBModels;
using Domain.RespDTO.MasterSchemaRespDTO;

namespace DiriAPI.Services.MasterSchemaServices
{
    public class OccupationalDesignationService
    {
        private DiriWebPortalContext _diriWebPortalContext;
        private OccupationaleDesignationRespDTO _respDTO;
        private List<OccupationalDesignation> _lstDesignation;
        public OccupationalDesignationService(DiriWebPortalContext diriWebPortalContext)
        {
            _diriWebPortalContext = diriWebPortalContext;
        }

        public OccupationaleDesignationRespDTO GetAllOccDesignationList()
        {
            _respDTO = new();
            _lstDesignation = new();
            try
            {
                _lstDesignation = _diriWebPortalContext.OccupationalDesignations.Where(x => x.Active == 1).ToList();
                if (_lstDesignation != null)
                {
                    _respDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _respDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _respDTO.lstData = _lstDesignation;
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

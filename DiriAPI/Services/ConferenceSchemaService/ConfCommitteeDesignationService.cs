using DataAccess.Core;
using Domain.DBModels;
using Domain.RespDTO.ConferenceSchemaRespDTO;
using Domain.RespDTO.MasterSchemaRespDTO;

namespace DiriAPI.Services.ConferenceSchemaService
{
    public class ConfCommitteeDesignationService
    {
        private DiriWebPortalContext _diriWebPortalContext;
        private ConfCommitteeDesignationRespDTO _respDTO;
        private List<ConfCommitteeDesignation> _lstConfCommitteeDesignation;
        public ConfCommitteeDesignationService(DiriWebPortalContext diriWebPortalContext)
        {
            _diriWebPortalContext = diriWebPortalContext;
        }

        public ConfCommitteeDesignationRespDTO GetAllConfCommDesignationList()
        {
            _respDTO = new();
            _lstConfCommitteeDesignation = new();
            try
            {
                _lstConfCommitteeDesignation = _diriWebPortalContext.ConfCommitteeDesignations.Where(x => x.Active == 1).ToList();
                if (_lstConfCommitteeDesignation != null)
                {
                    _respDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _respDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _respDTO.lstData = _lstConfCommitteeDesignation;
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

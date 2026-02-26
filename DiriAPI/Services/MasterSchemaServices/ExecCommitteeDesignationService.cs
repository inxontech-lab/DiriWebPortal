using DataAccess.Core;
using Domain.DBModels;
using Domain.RespDTO.MasterSchemaRespDTO;

namespace DiriAPI.Services.MasterSchemaServices
{
    public class ExecCommitteeDesignationService
    {
        private DiriWebPortalContext _diriWebPortalContext;
        private ExecutiveCommitteeDesignationRespDTO _respDTO;
        private List<ExecutiveCommitteeDesignation> _lstDesignation;
        public ExecCommitteeDesignationService(DiriWebPortalContext diriWebPortalContext)
        {
            _diriWebPortalContext = diriWebPortalContext;
        }

        public ExecutiveCommitteeDesignationRespDTO GetAllExecDesignationList()
        {
            _respDTO = new();
            _lstDesignation = new();
            try
            {
                _lstDesignation = _diriWebPortalContext.ExecutiveCommitteeDesignations.Where(x => x.Active == 1).ToList();
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

using DataAccess.Core;
using DataAccess.Repository;
using Domain.DBModels;
using Domain.DTO.ConferenceSchemaDTO;
using Domain.RespDTO.ConferenceSchemaRespDTO;

namespace DiriAPI.Services.ConferenceSchemaService
{
    public class ConferenceMasterService
    {
        private DiriWebPortalContext _diriWebPortalContext;
        private IDiriContextDataRepo _diriContextDataRepo;
        private ConferenceMasterRespDTO _respDTO;
        private List<ConferenceMaster> _lstConference;

        private UpcomingConferenceRespDTO _ConferenceDetailsDTO;
        private List<ConferenceDetailsDTO> _lstConferenceDetailsDTO;


        public ConferenceMasterService(DiriWebPortalContext diriWebPortalContext, 
            IDiriContextDataRepo diriContextDataRepo)
        {
            _diriWebPortalContext = diriWebPortalContext;
            _diriContextDataRepo = diriContextDataRepo;
        }

        public ConferenceMasterRespDTO GetAllConferenceList()
        {
            _respDTO = new();
            _lstConference = new();
            try
            {
                _lstConference = _diriWebPortalContext.ConferenceMasters.Where(x => x.Active == 1 && x.HighlightSwitch == 0).OrderByDescending(x => x.ConferenceYear).ToList();
                if (_lstConference != null)
                {
                    _respDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _respDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _respDTO.lstData = _lstConference;
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

        public async Task<UpcomingConferenceRespDTO> GetUpcomingConferenceDetails()
        {
            _ConferenceDetailsDTO = new();
            _lstConferenceDetailsDTO = new();
            try
            {
                //_lstConferenceDetailsDTO = await _diriContextDataRepo.GetUpcomingConferenceDetails();
                if (_lstConferenceDetailsDTO != null && _lstConferenceDetailsDTO.Count() > 0)
                {
                    _ConferenceDetailsDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _ConferenceDetailsDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _ConferenceDetailsDTO._lstConferenceDetailsDTO = _lstConferenceDetailsDTO;
                }
                else
                {
                    _ConferenceDetailsDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _ConferenceDetailsDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _ConferenceDetailsDTO._lstConferenceDetailsDTO = null;
                }
            }
            catch(Exception ex)
            {
                _ConferenceDetailsDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                _ConferenceDetailsDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                _ConferenceDetailsDTO._lstConferenceDetailsDTO = null;
            }
            return _ConferenceDetailsDTO;
        }
    }
}

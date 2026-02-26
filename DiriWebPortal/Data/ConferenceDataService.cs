using Domain.DBModels;
using Domain.DTO.ConferenceSchemaDTO;
using Domain.RespDTO.AboutUsPageRespDTO;
using Domain.RespDTO.ConferenceSchemaRespDTO;
using Newtonsoft.Json;

namespace DiriWebPortal.Data
{
    public class ConferenceDataService
    {
        private ServiceClient serviceClient { get; set; } = new();
        private ConferenceMasterRespDTO conferenceMasterRespDTO { get; set; }
        private UpcomingConferenceRespDTO upcomingConferenceRespDTO { get; set; }
        private List<ConferenceMaster> conferenceMaster { get; set; }
        private List<ConferenceDetailsDTO>? conferenceDetailsDTOs;

        private IConfiguration _configuration;
        public ConferenceDataService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<ConferenceMaster>> GetConferenceHistory()
        {
            conferenceMasterRespDTO = new();
            conferenceMaster = new();
            string retrunString = null;
            retrunString = await serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"Conference/GetAllConferenceList");
            conferenceMasterRespDTO = JsonConvert.DeserializeObject<ConferenceMasterRespDTO>(retrunString);
            if (conferenceMasterRespDTO != null && conferenceMasterRespDTO.RESPONSE_CODE.Equals("000"))
            {
                conferenceMaster = conferenceMasterRespDTO.lstData;
            }
            return conferenceMaster;
        }

        public async Task<List<ConferenceDetailsDTO>> UpcomingConference()
        {
            upcomingConferenceRespDTO = new();
            conferenceDetailsDTOs = new();
            string retrunString = null;
            retrunString = await serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"Conference/GetUpcomingConferenceDetails");
            upcomingConferenceRespDTO = JsonConvert.DeserializeObject<UpcomingConferenceRespDTO>(retrunString);
            if (upcomingConferenceRespDTO != null && upcomingConferenceRespDTO.RESPONSE_CODE.Equals("000"))
            {
                conferenceDetailsDTOs = upcomingConferenceRespDTO._lstConferenceDetailsDTO;
            }
            return conferenceDetailsDTOs;
        }
    }
}

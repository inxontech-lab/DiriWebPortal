using DiriWebPortal.Data;
using Domain.DBModels;
using Domain.DTO.ConferenceSchemaDTO;
using Domain.DTO.JournalSchemaDTO;
using Ganss.Xss;
using Microsoft.AspNetCore.Components;

namespace DiriWebPortal.Pages.Conference
{
    public partial class UpcomingConference
    {
        [Parameter] public int ConferenceId { get; set; }
        [Inject]
        private ConferenceDataService ConferenceDataService { get; set; }
        [Inject]
        private HomePageDataService _HomePageDataService { get; set; }
        private List<ConferenceDetailsDTO>? _conferenceDetailsDTOs { get; set; }
        public ConferenceDetailsDTO? ConferenceDetails { get; set; }
        protected FounderInfo founderInfo { get; set; }
        protected ManagingTrusteeInfo managingTrusteeInfo { get; set; }
        public HtmlSanitizer sanitizer;


        protected async override Task OnInitializedAsync()
        {
            sanitizer = new HtmlSanitizer();
            _conferenceDetailsDTOs = await ConferenceDataService.UpcomingConference();
            if (_conferenceDetailsDTOs != null && _conferenceDetailsDTOs.Count() > 0)
            {
                ConferenceDetails = _conferenceDetailsDTOs.Where(x => x.Id == ConferenceId).FirstOrDefault();
                founderInfo = await _HomePageDataService.GetFounderInfo();
                managingTrusteeInfo = await _HomePageDataService.GetManagingTrusteeInfo();
            }
        }
    }
}

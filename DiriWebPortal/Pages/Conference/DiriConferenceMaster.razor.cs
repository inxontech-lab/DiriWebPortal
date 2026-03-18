using Shared.WebClientService;
using Domain.DBModels;
using Microsoft.AspNetCore.Components;

namespace DiriWebPortal.Pages.Conference
{
    public partial class DiriConferenceMaster
    {
        [Inject]
        private ConferenceDataService _ConferenceDataService { get; set; }
        [Inject]
        private HomePageDataService _HomePageDataService { get; set; }
        private List<ConferenceMaster> conferenceMaster { get; set; }
        protected HighlightedEvent highlightedEvent { get; set; }
        protected async override Task OnInitializedAsync()
        {
            conferenceMaster = await _ConferenceDataService.GetConferenceHistory();
            highlightedEvent = await _HomePageDataService.GetHighlightedEvent();
        }
    }
}

using Shared.WebClientService;
using Domain.DTO.JournalSchemaDTO;
using Microsoft.AspNetCore.Components;

namespace DiriWebPortal.Pages.Journals
{
    public partial class JournalDetails
    {
        [Parameter] public int VolumeId { get; set; }
        [Inject]
        private JournalsDataService JournalsDataService { get; set; }
        private JournalDTO? _JournalDTO { get; set; }

        protected async override Task OnInitializedAsync()
        {
            _JournalDTO = await JournalsDataService.GetJournalDetailsByVolumeId(VolumeId);
        }
    }
}

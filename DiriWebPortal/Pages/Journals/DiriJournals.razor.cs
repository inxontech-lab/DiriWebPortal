using Shared.WebClientService;
using Domain.DBModels;
using Domain.DTO.JournalSchemaDTO;
using Microsoft.AspNetCore.Components;

namespace DiriWebPortal.Pages.Journals
{
    public partial class DiriJournals
    {
        [Inject]
        private JournalsDataService JournalsDataService { get; set; }
        private List<JournalVolumeDTO>? _lstJournal;

        protected async override Task OnInitializedAsync()
        {
            _lstJournal = await JournalsDataService.GetAllJournalList();
        }
    }
}

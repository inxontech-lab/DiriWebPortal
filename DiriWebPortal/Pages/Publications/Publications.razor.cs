using Shared.WebClientService;
using Domain.DBModels;
using Microsoft.AspNetCore.Components;

namespace DiriWebPortal.Pages.Publications
{
    public partial class Publications
    {
        [Inject]
        private PublicationsPageDataService publicationsPageDataService { get; set; }
        private List<PublicationTypeMaster> _publicationTypeMasters { get; set; }
        private List<BookMaster> _lstBooks { get; set; }

        protected async override Task OnInitializedAsync()
        {
            _publicationTypeMasters = await publicationsPageDataService.GetAllPublicationType();
            _lstBooks = await publicationsPageDataService.GetAllBooks(5); //id 5 is for publication, 1 is for journal
        }
    }
}

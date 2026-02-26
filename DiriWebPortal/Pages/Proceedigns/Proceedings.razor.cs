using DiriWebPortal.Data;
using Domain.DBModels;
using Microsoft.AspNetCore.Components;

namespace DiriWebPortal.Pages.Proceedigns
{
    public partial class Proceedings
    {
        [Inject]
        private PublicationsPageDataService publicationsPageDataService { get; set; }
        private List<PublicationTypeMaster> _publicationTypeMasters { get; set; }
        private List<BookMaster> _lstBooks { get; set; }

        protected async override Task OnInitializedAsync()
        {
            _publicationTypeMasters = await publicationsPageDataService.GetAllPublicationType();
            _lstBooks = await publicationsPageDataService.GetAllBooks(2); //id 2 is for proceedings
        }

    }
}

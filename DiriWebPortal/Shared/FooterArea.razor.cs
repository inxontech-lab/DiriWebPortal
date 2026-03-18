using Shared.WebClientService;
using Domain.DBModels;
using Microsoft.AspNetCore.Components;

namespace DiriWebPortal.Shared
{
    public partial class FooterArea
    {
        [Inject]
        private HomePageDataService _HomePageDataService { get; set; }

        protected ContactU contactUs { get; set; }

        protected async override Task OnInitializedAsync()
        {
            contactUs = await _HomePageDataService.GetOrganizationalData();
        }
    }
}

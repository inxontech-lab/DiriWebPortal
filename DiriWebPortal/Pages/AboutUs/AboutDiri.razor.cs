using Shared.WebClientService;
using Domain.DBModels;
using Microsoft.AspNetCore.Components;

namespace DiriWebPortal.Pages.AboutUs
{
    public partial class AboutDiri
    {
        [Inject]
        private AboutUsPageDataService _aboutUsPageDataService { get; set; }
        private AboutUsDetail aboutUsDetails { get; set; }
        protected async override Task OnInitializedAsync()
        {
            aboutUsDetails = await _aboutUsPageDataService.GetAboutUsDetails();
        }
    }
}

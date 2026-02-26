using DiriWebPortal.Data;
using Domain.DBModels;
using Microsoft.AspNetCore.Components;

namespace DiriWebPortal.Pages.AboutUs
{
    public partial class Founder
    {
        [Inject]
        private HomePageDataService _HomePageDataService { get; set; }
        protected FounderInfo founderInfo { get; set; }
        protected async override Task OnInitializedAsync()
        {
            founderInfo = await _HomePageDataService.GetFounderInfo();
        }
    }
}

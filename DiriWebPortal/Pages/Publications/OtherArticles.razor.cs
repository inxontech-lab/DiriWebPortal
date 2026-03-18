using Shared.WebClientService;
using Domain.DBModels;
using Domain.DTO.JournalSchemaDTO;
using Domain.DTO.PublicationShemaDTO;
using Domain.RespDTO.PublicationsRespDTO;
using Microsoft.AspNetCore.Components;

namespace DiriWebPortal.Pages.Publications
{
    public partial class OtherArticles
    {
        [Inject]
        private PublicationsPageDataService PublicationsPageDataService { get; set; }
        private List<PublicationsArticlesDTO>? _lstPublicationsArticles { get; set; }
        protected async override Task OnInitializedAsync()
        {
            _lstPublicationsArticles = await PublicationsPageDataService.GetPublicationArticleList();
        }
    }
}

using DiriWebPortal.Data;
using Domain.DBModels;
using Domain.RespDTO.PublicationsRespDTO;
using Microsoft.AspNetCore.Components;

namespace DiriWebPortal.Pages.Publications
{
    public partial class BookDetailsReader
    {
        [Parameter] public int BookId { get; set; }
        [Inject]
        private PublicationsPageDataService publicationsPageDataService { get; set; }
        public string BookName { get; set; }
        public string BookName2 { get; set; }
        public string WritterName { get; set; }
        public string ShortDescription { get; set; }
        public string ImagePath { get; set; }
        private List<BookDetailsDTO> _lstBookDetailsDTO { get; set; }

        protected async override Task OnInitializedAsync()
        {
            //BookName = "Waliyat-e-Mutlaka";
            //BookName2 = "Waliyat-e-Mutlaka (English)";
            //WritterName = "Syed Delaor Hossain Maizbhandari";
            //ShortDescription = "ShortDesc";
            //ImagePath = "Thumbnail/Publications/Waliyat e Mutlaka (En).jpeg";

            _lstBookDetailsDTO = await publicationsPageDataService.GetBookDetails(BookId);
        }
    }
}

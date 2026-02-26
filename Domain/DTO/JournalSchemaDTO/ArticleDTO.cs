using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.JournalSchemaDTO
{
    public class ArticleDTO
    {
        public int ArticleId { get; set; }
        public int VolumeId { get; set; }
        public string? Title { get; set; }
        public string? Abstract { get; set; }
        public string? DOI { get; set; }
        public string? PDFUrl { get; set; }
        public string? Keywords { get; set; }
        public string? Pages { get; set; }
        public string? Language { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? PublishedDate { get; set; }

        public List<ResearcherDTO> Authors { get; set; } = new();
    }
}

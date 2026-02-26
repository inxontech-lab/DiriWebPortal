using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.JournalSchemaDTO
{
    public class VolumeDTO
    {
        public int VolumeId { get; set; }
        public int JournalId { get; set; }
        public int VolumeNumber { get; set; }
        public int? IssueNumber { get; set; }
        public int? PublicationYear { get; set; }
        public string? PublicationMonth { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string? Description { get; set; }
        public string? EditorialBoard { get; set; }
        public string? Editorial { get; set; }
        public string? DOI_Prefix { get; set; }
        public string? PdfUrl { get; set; }
        public string? Thumbnail { get; set; }

        public List<ArticleDTO> Articles { get; set; } = new();
    }
}

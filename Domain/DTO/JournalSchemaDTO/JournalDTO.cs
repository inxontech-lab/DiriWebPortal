using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.JournalSchemaDTO
{
    public class JournalDTO
    {
        public int JournalId { get; set; }
        public int? InstituteId { get; set; }
        public string? JournalName { get; set; }
        public string? ISSN { get; set; }
        public string? PublisherName { get; set; }
        public string? Description { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? Thumbnail { get; set; }
        public string? PdfUrl { get; set; }
        public DateTime? CreatedDate { get; set; }

        public VolumeDTO? Volume { get; set; }
    }
}

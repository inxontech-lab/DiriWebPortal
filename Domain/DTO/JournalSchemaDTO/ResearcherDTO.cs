using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.JournalSchemaDTO
{
    public class ResearcherDTO
    {
        public int ResearcherId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Affiliation { get; set; }
        public string? ORCID { get; set; }
        public string? Website { get; set; }
        public string? Country { get; set; }
        public string? Biography { get; set; }
        public string? PhotoUrl { get; set; }
        public DateTime? CreatedDate { get; set; }

        public int? AuthorOrder { get; set; }
        public bool? IsCorrespondingAuthor { get; set; }
    }
}

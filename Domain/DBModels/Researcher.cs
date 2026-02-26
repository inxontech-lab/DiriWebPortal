using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class Researcher
    {
        public Researcher()
        {
            ArticleAuthors = new HashSet<ArticleAuthor>();
        }

        public int ResearcherId { get; set; }
        public string FullName { get; set; } = null!;
        public string? Email { get; set; }
        public string? Affiliation { get; set; }
        public string? Orcid { get; set; }
        public string? Website { get; set; }
        public string? Country { get; set; }
        public string? Biography { get; set; }
        public string? PhotoUrl { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<ArticleAuthor> ArticleAuthors { get; set; }
    }
}

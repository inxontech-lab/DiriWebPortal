using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class Article
    {
        public Article()
        {
            ArticleAuthors = new HashSet<ArticleAuthor>();
            References = new HashSet<Reference>();
        }

        public int ArticleId { get; set; }
        public int VolumeId { get; set; }
        public string Title { get; set; } = null!;
        public string? Abstract { get; set; }
        public string? Doi { get; set; }
        public string? Pdfurl { get; set; }
        public string? Keywords { get; set; }
        public string? Pages { get; set; }
        public string? Language { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? PublishedDate { get; set; }

        public virtual Volume Volume { get; set; } = null!;
        public virtual ICollection<ArticleAuthor> ArticleAuthors { get; set; }
        public virtual ICollection<Reference> References { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ArticleAuthor
    {
        public int ArticleId { get; set; }
        public int ResearcherId { get; set; }
        public int? AuthorOrder { get; set; }
        public bool? IsCorrespondingAuthor { get; set; }

        public virtual Article Article { get; set; } = null!;
        public virtual Researcher Researcher { get; set; } = null!;
    }
}

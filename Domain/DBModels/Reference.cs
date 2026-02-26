using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class Reference
    {
        public int ReferenceId { get; set; }
        public int ArticleId { get; set; }
        public string ReferenceText { get; set; } = null!;
        public string? ReferenceDoi { get; set; }
        public string? ReferenceUrl { get; set; }
        public string? Authors { get; set; }
        public int? PublicationYear { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Article Article { get; set; } = null!;
    }
}

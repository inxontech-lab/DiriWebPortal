using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ManagingTrusteePublication
    {
        public int Id { get; set; }
        public string? PublicationName { get; set; }
        public string? ShortDescription { get; set; }
        public string? PublicationLink { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int? Active { get; set; }
    }
}

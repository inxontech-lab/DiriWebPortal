using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ArticleAttachment
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string AttachmentLocation { get; set; } = null!;
        public string? AttachmentTittle { get; set; }
        public int? AttachmentSerial { get; set; }
        public int Active { get; set; }
    }
}

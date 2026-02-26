using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class BookAttachment
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string? AttachmentLocation { get; set; }
        public string? AttachmentTittle { get; set; }
        public int? AttachmentSerial { get; set; }
        public int? Active { get; set; }
    }
}

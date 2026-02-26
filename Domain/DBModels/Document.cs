using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class Document
    {
        public int DocumentId { get; set; }
        public int RequestId { get; set; }
        public int RefNumber { get; set; }
        public int FileTypeId { get; set; }
        public string? Size { get; set; }
        public string? Note { get; set; }
        public int Active { get; set; }
    }
}

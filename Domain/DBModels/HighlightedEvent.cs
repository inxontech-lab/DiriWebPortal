using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class HighlightedEvent
    {
        public int Id { get; set; }
        public string? Heading1 { get; set; }
        public string? Heading2 { get; set; }
        public string? Heading3 { get; set; }
        public string? Heading4 { get; set; }
        public string? ImagePath { get; set; }
        public string? ImageDescription { get; set; }
        public string? Description { get; set; }
        public int? Active { get; set; }
    }
}

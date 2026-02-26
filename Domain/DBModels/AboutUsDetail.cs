using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class AboutUsDetail
    {
        public int Id { get; set; }
        public string? Heading1 { get; set; }
        public string? Heading2 { get; set; }
        public string? Heading3 { get; set; }
        public string? Heading4 { get; set; }
        public string? AboutUsDetails { get; set; }
        public string? YearsOfJourney { get; set; }
        public int? Active { get; set; }
    }
}

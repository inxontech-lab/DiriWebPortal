using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class FounderInfo
    {
        public int Id { get; set; }
        public string? FounderName { get; set; }
        public string? FounderTittle1 { get; set; }
        public string? FounderTittle2 { get; set; }
        public string? FounderMessage { get; set; }
        public string? AboutFounder { get; set; }
        public string? FounderImagePath { get; set; }
        public int? Active { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

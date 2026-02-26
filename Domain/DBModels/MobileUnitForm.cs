using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class MobileUnitForm
    {
        public int FormId { get; set; }
        public string? RequesterCpr { get; set; }
        public string? Mobile { get; set; }
        public string? BlockNumber { get; set; }
        public string? Address { get; set; }
        public string? Note { get; set; }
        public int RequestId { get; set; }
        public string? SecondContactNum { get; set; }
        public int? Active { get; set; }

        public virtual Request Request { get; set; } = null!;
    }
}

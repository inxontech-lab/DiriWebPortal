using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class RadiologyRequest
    {
        public int RadReqId { get; set; }
        public string? RequesterCpr { get; set; }
        public string? Consent { get; set; }
        public string? Mobile { get; set; }
        public int RequestId { get; set; }
        public string? SecondContNum { get; set; }
        public int? Active { get; set; }

        public virtual Request Request { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class SehatiCardRequest
    {
        public int CardId { get; set; }
        public string? NewBornCpr { get; set; }
        public string? FatherCpr { get; set; }
        public string? MotherCpr { get; set; }
        public string? FatherMobile { get; set; }
        public int? BlockNumber { get; set; }
        public int RequestId { get; set; }
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }
        public string? Note { get; set; }
        public int? Active { get; set; }

        public virtual Request Request { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class MedicationRefillForm
    {
        public int MedicationRefillFormId { get; set; }
        public string? RequesterCpr { get; set; }
        public string? Mobile { get; set; }
        public int? Block { get; set; }
        public int RequestId { get; set; }
        public int? Active { get; set; }

        public virtual Request Request { get; set; } = null!;
    }
}

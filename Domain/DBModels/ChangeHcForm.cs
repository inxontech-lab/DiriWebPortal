using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ChangeHcForm
    {
        public int ChangeFormId { get; set; }
        public string? RequesterCpr { get; set; }
        public int? Block { get; set; }
        public int PreviousHealthCenter { get; set; }
        public int NewHealthcenter { get; set; }
        public int RequestId { get; set; }
        public int? Active { get; set; }

        public virtual Request Request { get; set; } = null!;
    }
}

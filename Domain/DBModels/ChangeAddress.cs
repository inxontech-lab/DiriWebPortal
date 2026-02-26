using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ChangeAddress
    {
        public int Id { get; set; }
        public string? RequesterCpr { get; set; }
        public int? PreviousBlock { get; set; }
        public int? NewBlock { get; set; }
        public string? Mobile { get; set; }
        public int RequestId { get; set; }
        public string? SecondConNum { get; set; }
        public string? Email { get; set; }
        public string? Note { get; set; }
        public int? Active { get; set; }

        public virtual Request Request { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class InstructionMaster
    {
        public int Id { get; set; }
        public string InstructionTitle { get; set; } = null!;
        public int? Active { get; set; }
    }
}

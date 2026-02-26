using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class PlatformMaster
    {
        public int Id { get; set; }
        public string? ConfPlatform { get; set; }
        public int? Active { get; set; }
    }
}

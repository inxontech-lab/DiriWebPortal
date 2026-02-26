using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class MainThemeMaster
    {
        public int Id { get; set; }
        public string Theme { get; set; } = null!;
        public int? Active { get; set; }
    }
}

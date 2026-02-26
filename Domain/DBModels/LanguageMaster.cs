using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class LanguageMaster
    {
        public int Id { get; set; }
        public string? LanguageName { get; set; }
        public int? Active { get; set; }
    }
}

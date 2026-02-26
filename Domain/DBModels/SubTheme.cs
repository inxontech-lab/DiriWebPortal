using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class SubTheme
    {
        public int Id { get; set; }
        public int? MainThemeId { get; set; }
        public string? SubTheme1 { get; set; }
        public int? Active { get; set; }
    }
}

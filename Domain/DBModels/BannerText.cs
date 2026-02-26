using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class BannerText
    {
        public int Id { get; set; }
        public string? BannerImageLocation { get; set; }
        public string? TitleText { get; set; }
        public string? Subtitle { get; set; }
        public int Active { get; set; }
    }
}

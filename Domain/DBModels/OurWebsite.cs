using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class OurWebsite
    {
        public string? WebsiteTittle { get; set; }
        public string? Url { get; set; }
        public int? SerialNumber { get; set; }
        public int? Active { get; set; }
    }
}

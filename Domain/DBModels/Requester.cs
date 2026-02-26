using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class Requester
    {
        public Requester()
        {
            Requests = new HashSet<Request>();
        }

        public int RequesterId { get; set; }
        public string RequesterCpr { get; set; } = null!;
        public string RequesterName { get; set; } = null!;
        public string? MobileNumber { get; set; }
        public int BlockNumber { get; set; }
        public string? Note { get; set; }
        public int Active { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}

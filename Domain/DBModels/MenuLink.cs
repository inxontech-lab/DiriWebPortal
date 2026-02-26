using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class MenuLink
    {
        public int Id { get; set; }
        public int? ParentMenuId { get; set; }
        public string? MenuName { get; set; }
        public string? PageLink { get; set; }
        public int? Active { get; set; }
    }
}

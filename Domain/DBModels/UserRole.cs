using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class UserRole
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime? AssignedDate { get; set; }
        public string? AssignedBy { get; set; }

        public virtual RoleMaster Role { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}

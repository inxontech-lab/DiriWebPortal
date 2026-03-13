using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string LoginId { get; set; } = null!;
        public string? Email { get; set; }
        public string? MobileNo { get; set; }
        public string PasswordHash { get; set; } = null!;
        public bool? IsActive { get; set; }
        public bool? IsLocked { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}

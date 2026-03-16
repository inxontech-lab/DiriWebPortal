using System.ComponentModel.DataAnnotations;

namespace Domain.DTO.MasterSchemaDTO
{
    public class UserWithRolesDTO
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "User Name is required.")]
        public string UserName { get; set; } = string.Empty;


        [EmailAddress(ErrorMessage = "Email is not valid.")]
        public string? Email { get; set; }

        public string? MobileNo { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string PasswordHash { get; set; } = string.Empty;

        public bool? IsActive { get; set; } = true;
        public bool? IsLocked { get; set; } = false;
        public DateTime? LastLoginDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }

        [MinLength(1, ErrorMessage = "At least one role is required.")]
        public List<int> RoleIds { get; set; } = new();
    }
}

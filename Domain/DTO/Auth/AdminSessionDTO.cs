namespace Domain.DTO.Auth;

public class AdminSessionDTO
{
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public List<int> RoleIds { get; set; } = new();
    public DateTime LoginTimeUtc { get; set; } = DateTime.UtcNow;
}

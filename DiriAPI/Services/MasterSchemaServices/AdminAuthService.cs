using DataAccess.Core;
using Domain.DTO.Auth;
using Domain.RespDTO.Auth;
using Microsoft.EntityFrameworkCore;
using DiriAPI.Services.Security;

namespace DiriAPI.Services.MasterSchemaServices;

public class AdminAuthService
{
    private readonly DiriWebPortalContext _context;
    private readonly PasswordHashingService _passwordHashingService;

    public AdminAuthService(DiriWebPortalContext context, PasswordHashingService passwordHashingService)
    {
        _context = context;
        _passwordHashingService = passwordHashingService;
    }

    public AdminLoginRespDTO Login(AdminLoginRequestDTO request)
    {
        var response = new AdminLoginRespDTO();

        try
        {
            var normalizedUserName = request.UserName?.Trim();
            var user = _context.Users
                .Include(x => x.UserRoles)
                .FirstOrDefault(x => x.UserName == normalizedUserName);

            if (user is null || !_passwordHashingService.VerifyPassword(request.Password, user.PasswordHash))
            {
                response.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                response.RESPONSE_DESCRPTION = "Invalid user name or password.";
                return response;
            }

            if (user.IsActive == false)
            {
                response.RESPONSE_CODE = ConfigClass.ERROR;
                response.RESPONSE_DESCRPTION = "This user account is inactive.";
                return response;
            }

            if (user.IsLocked == true)
            {
                response.RESPONSE_CODE = ConfigClass.ERROR;
                response.RESPONSE_DESCRPTION = "This user account is locked.";
                return response;
            }

            if (_passwordHashingService.NeedsRehash(user.PasswordHash))
            {
                user.PasswordHash = _passwordHashingService.HashPassword(request.Password);
            }

            user.LastLoginDate = DateTime.Now;
            user.ModifiedDate = DateTime.Now;
            _context.SaveChanges();

            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = "Login successful.";
            response.data = new AdminSessionDTO
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                RoleIds = user.UserRoles.Select(x => x.RoleId).Distinct().ToList(),
                LoginTimeUtc = DateTime.UtcNow
            };
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }
}

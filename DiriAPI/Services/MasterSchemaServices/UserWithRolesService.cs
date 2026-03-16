using DataAccess.Core;
using Domain.DBModels;
using Domain.DTO.MasterSchemaDTO;
using Domain.RespDTO.MasterSchemaRespDTO;
using Microsoft.EntityFrameworkCore;

namespace DiriAPI.Services.MasterSchemaServices
{
    public class UserWithRolesService
    {
        private readonly DiriWebPortalContext _context;

        public UserWithRolesService(DiriWebPortalContext context)
        {
            _context = context;
        }

        public UserWithRolesRespDTO GetAll()
        {
            var resp = new UserWithRolesRespDTO();
            try
            {
                var users = _context.Users
                    .Include(x => x.UserRoles)
                    .ThenInclude(ur => ur.Role)
                    .OrderBy(x => x.UserName)
                    .ToList();

                resp.RESPONSE_CODE = ConfigClass.SUCCESS;
                resp.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                resp.lstData = users.Select(MapToDto).ToList();
            }
            catch (Exception ex)
            {
                resp.RESPONSE_CODE = ConfigClass.ERROR;
                resp.RESPONSE_DESCRPTION = ex.Message;
            }

            return resp;
        }

        public UserWithRolesRespDTO GetById(int id)
        {
            var resp = new UserWithRolesRespDTO();
            try
            {
                var user = _context.Users
                    .Include(x => x.UserRoles)
                    .ThenInclude(ur => ur.Role)
                    .FirstOrDefault(x => x.UserId == id);

                if (user == null)
                {
                    resp.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    resp.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    return resp;
                }

                resp.RESPONSE_CODE = ConfigClass.SUCCESS;
                resp.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                resp.data = MapToDto(user);
            }
            catch (Exception ex)
            {
                resp.RESPONSE_CODE = ConfigClass.ERROR;
                resp.RESPONSE_DESCRPTION = ex.Message;
            }

            return resp;
        }

        public UserWithRolesRespDTO Create(UserWithRolesDTO dto)
        {
            var resp = new UserWithRolesRespDTO();
            using var trx = _context.Database.BeginTransaction();
            try
            {
                var user = new User
                {
                    UserName = dto.UserName,
                    LoginId = dto.LoginId,
                    Email = dto.Email,
                    MobileNo = dto.MobileNo,
                    PasswordHash = dto.PasswordHash,
                    IsActive = dto.IsActive,
                    IsLocked = dto.IsLocked,
                    LastLoginDate = dto.LastLoginDate,
                    CreatedBy = dto.CreatedBy,
                    CreatedDate = dto.CreatedDate ?? DateTime.Now
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                var roles = BuildUserRoles(user.UserId, dto.RoleIds, dto.ModifiedBy ?? dto.CreatedBy);
                _context.UserRoles.AddRange(roles);
                _context.SaveChanges();

                trx.Commit();

                resp.RESPONSE_CODE = ConfigClass.SUCCESS;
                resp.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                resp.data = GetById(user.UserId).data;
            }
            catch (Exception ex)
            {
                trx.Rollback();
                resp.RESPONSE_CODE = ConfigClass.ERROR;
                resp.RESPONSE_DESCRPTION = ex.Message;
            }

            return resp;
        }

        public UserWithRolesRespDTO Update(int id, UserWithRolesDTO dto)
        {
            var resp = new UserWithRolesRespDTO();
            using var trx = _context.Database.BeginTransaction();
            try
            {
                var user = _context.Users
                    .Include(x => x.UserRoles)
                    .FirstOrDefault(x => x.UserId == id);

                if (user == null)
                {
                    resp.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    resp.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    return resp;
                }

                user.UserName = dto.UserName;
                user.LoginId = dto.LoginId;
                user.Email = dto.Email;
                user.MobileNo = dto.MobileNo;
                user.PasswordHash = dto.PasswordHash;
                user.IsActive = dto.IsActive;
                user.IsLocked = dto.IsLocked;
                user.LastLoginDate = dto.LastLoginDate;
                user.ModifiedBy = dto.ModifiedBy;
                user.ModifiedDate = DateTime.Now;

                _context.UserRoles.RemoveRange(user.UserRoles);
                var roles = BuildUserRoles(user.UserId, dto.RoleIds, dto.ModifiedBy ?? dto.CreatedBy);
                _context.UserRoles.AddRange(roles);

                _context.SaveChanges();
                trx.Commit();

                resp.RESPONSE_CODE = ConfigClass.SUCCESS;
                resp.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                resp.data = GetById(id).data;
            }
            catch (Exception ex)
            {
                trx.Rollback();
                resp.RESPONSE_CODE = ConfigClass.ERROR;
                resp.RESPONSE_DESCRPTION = ex.Message;
            }

            return resp;
        }

        public UserWithRolesRespDTO Delete(int id)
        {
            var resp = new UserWithRolesRespDTO();
            using var trx = _context.Database.BeginTransaction();
            try
            {
                var user = _context.Users
                    .Include(x => x.UserRoles)
                    .FirstOrDefault(x => x.UserId == id);

                if (user == null)
                {
                    resp.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    resp.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    return resp;
                }

                _context.UserRoles.RemoveRange(user.UserRoles);
                _context.Users.Remove(user);
                _context.SaveChanges();

                trx.Commit();

                resp.RESPONSE_CODE = ConfigClass.SUCCESS;
                resp.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
            }
            catch (Exception ex)
            {
                trx.Rollback();
                resp.RESPONSE_CODE = ConfigClass.ERROR;
                resp.RESPONSE_DESCRPTION = ex.Message;
            }

            return resp;
        }

        private static List<UserRole> BuildUserRoles(int userId, IEnumerable<int> roleIds, string? assignedBy)
        {
            return roleIds.Distinct().Select(roleId => new UserRole
            {
                UserId = userId,
                RoleId = roleId,
                AssignedBy = assignedBy,
                AssignedDate = DateTime.Now
            }).ToList();
        }

        private static UserWithRolesDTO MapToDto(User user)
        {
            return new UserWithRolesDTO
            {
                UserId = user.UserId,
                UserName = user.UserName,
                LoginId = user.LoginId,
                Email = user.Email,
                MobileNo = user.MobileNo,
                PasswordHash = user.PasswordHash,
                IsActive = user.IsActive,
                IsLocked = user.IsLocked,
                LastLoginDate = user.LastLoginDate,
                CreatedBy = user.CreatedBy,
                CreatedDate = user.CreatedDate,
                ModifiedBy = user.ModifiedBy,
                ModifiedDate = user.ModifiedDate,
                RoleIds = user.UserRoles.Select(x => x.RoleId).Distinct().ToList()
            };
        }
    }
}

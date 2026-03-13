using DataAccess.Core;
using Domain.DBModels;
using Domain.RespDTO.MasterSchemaRespDTO;

namespace DiriAPI.Services.MasterSchemaServices
{
    public class UserRolesService
    {
        private readonly DiriWebPortalContext _context;

        public UserRolesService(DiriWebPortalContext context)
        {
            _context = context;
        }

        public UserRoleRespDTO GetAll()
        {
            var resp = new UserRoleRespDTO();
            try
            {
                var userRoles = _context.UserRoles.OrderBy(x => x.UserRoleId).ToList();
                resp.RESPONSE_CODE = ConfigClass.SUCCESS;
                resp.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                resp.lstData = userRoles;
            }
            catch (Exception ex)
            {
                resp.RESPONSE_CODE = ConfigClass.ERROR;
                resp.RESPONSE_DESCRPTION = ex.Message;
            }

            return resp;
        }

        public UserRoleRespDTO GetById(int id)
        {
            var resp = new UserRoleRespDTO();
            try
            {
                var userRole = _context.UserRoles.FirstOrDefault(x => x.UserRoleId == id);
                if (userRole == null)
                {
                    resp.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    resp.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    return resp;
                }

                resp.RESPONSE_CODE = ConfigClass.SUCCESS;
                resp.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                resp.data = userRole;
            }
            catch (Exception ex)
            {
                resp.RESPONSE_CODE = ConfigClass.ERROR;
                resp.RESPONSE_DESCRPTION = ex.Message;
            }

            return resp;
        }

        public UserRoleRespDTO Create(UserRole userRole)
        {
            var resp = new UserRoleRespDTO();
            try
            {
                userRole.AssignedDate ??= DateTime.Now;
                _context.UserRoles.Add(userRole);
                _context.SaveChanges();

                resp.RESPONSE_CODE = ConfigClass.SUCCESS;
                resp.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                resp.data = userRole;
            }
            catch (Exception ex)
            {
                resp.RESPONSE_CODE = ConfigClass.ERROR;
                resp.RESPONSE_DESCRPTION = ex.Message;
            }

            return resp;
        }

        public UserRoleRespDTO Update(int id, UserRole userRole)
        {
            var resp = new UserRoleRespDTO();
            try
            {
                var existing = _context.UserRoles.FirstOrDefault(x => x.UserRoleId == id);
                if (existing == null)
                {
                    resp.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    resp.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    return resp;
                }

                existing.UserId = userRole.UserId;
                existing.RoleId = userRole.RoleId;
                existing.AssignedDate = userRole.AssignedDate;
                existing.AssignedBy = userRole.AssignedBy;

                _context.SaveChanges();

                resp.RESPONSE_CODE = ConfigClass.SUCCESS;
                resp.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                resp.data = existing;
            }
            catch (Exception ex)
            {
                resp.RESPONSE_CODE = ConfigClass.ERROR;
                resp.RESPONSE_DESCRPTION = ex.Message;
            }

            return resp;
        }

        public UserRoleRespDTO Delete(int id)
        {
            var resp = new UserRoleRespDTO();
            try
            {
                var existing = _context.UserRoles.FirstOrDefault(x => x.UserRoleId == id);
                if (existing == null)
                {
                    resp.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    resp.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    return resp;
                }

                _context.UserRoles.Remove(existing);
                _context.SaveChanges();

                resp.RESPONSE_CODE = ConfigClass.SUCCESS;
                resp.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
            }
            catch (Exception ex)
            {
                resp.RESPONSE_CODE = ConfigClass.ERROR;
                resp.RESPONSE_DESCRPTION = ex.Message;
            }

            return resp;
        }
    }
}

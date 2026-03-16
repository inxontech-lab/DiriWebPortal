using DataAccess.Core;
using Domain.DBModels;
using Domain.RespDTO.MasterSchemaRespDTO;

namespace DiriAPI.Services.MasterSchemaServices
{
    public class UsersService
    {
        private readonly DiriWebPortalContext _context;

        public UsersService(DiriWebPortalContext context)
        {
            _context = context;
        }

        public UserRespDTO GetAll()
        {
            var resp = new UserRespDTO();
            try
            {
                var users = _context.Users.OrderBy(x => x.UserName).ToList();
                resp.RESPONSE_CODE = ConfigClass.SUCCESS;
                resp.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                resp.lstData = users;
            }
            catch (Exception ex)
            {
                resp.RESPONSE_CODE = ConfigClass.ERROR;
                resp.RESPONSE_DESCRPTION = ex.Message;
            }

            return resp;
        }

        public UserRespDTO GetById(int id)
        {
            var resp = new UserRespDTO();
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.UserId == id);
                if (user == null)
                {
                    resp.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    resp.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    return resp;
                }

                resp.RESPONSE_CODE = ConfigClass.SUCCESS;
                resp.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                resp.data = user;
            }
            catch (Exception ex)
            {
                resp.RESPONSE_CODE = ConfigClass.ERROR;
                resp.RESPONSE_DESCRPTION = ex.Message;
            }

            return resp;
        }

        public UserRespDTO Create(User user)
        {
            var resp = new UserRespDTO();
            try
            {
                user.CreatedDate ??= DateTime.Now;
                _context.Users.Add(user);
                _context.SaveChanges();

                resp.RESPONSE_CODE = ConfigClass.SUCCESS;
                resp.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                resp.data = user;
            }
            catch (Exception ex)
            {
                resp.RESPONSE_CODE = ConfigClass.ERROR;
                resp.RESPONSE_DESCRPTION = ex.Message;
            }

            return resp;
        }

        public UserRespDTO Update(int id, User user)
        {
            var resp = new UserRespDTO();
            try
            {
                var existing = _context.Users.FirstOrDefault(x => x.UserId == id);
                if (existing == null)
                {
                    resp.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    resp.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    return resp;
                }

                existing.UserName = user.UserName;
                existing.Email = user.Email;
                existing.MobileNo = user.MobileNo;
                existing.PasswordHash = user.PasswordHash;
                existing.IsActive = user.IsActive;
                existing.IsLocked = user.IsLocked;
                existing.LastLoginDate = user.LastLoginDate;
                existing.ModifiedBy = user.ModifiedBy;
                existing.ModifiedDate = DateTime.Now;

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

        public UserRespDTO Delete(int id)
        {
            var resp = new UserRespDTO();
            try
            {
                var existing = _context.Users.FirstOrDefault(x => x.UserId == id);
                if (existing == null)
                {
                    resp.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    resp.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    return resp;
                }

                _context.Users.Remove(existing);
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

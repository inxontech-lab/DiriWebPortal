using DataAccess.Core;
using Domain.DBModels;
using Domain.RespDTO.MasterSchemaRespDTO;

namespace DiriAPI.Services.MasterSchemaServices
{
    public class RoleMasterService
    {
        private readonly DiriWebPortalContext _context;

        public RoleMasterService(DiriWebPortalContext context)
        {
            _context = context;
        }

        public RoleMasterRespDTO GetAll()
        {
            var resp = new RoleMasterRespDTO();
            try
            {
                var roles = _context.RoleMasters.OrderBy(x => x.RoleName).ToList();
                resp.RESPONSE_CODE = ConfigClass.SUCCESS;
                resp.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                resp.lstData = roles;
            }
            catch (Exception ex)
            {
                resp.RESPONSE_CODE = ConfigClass.ERROR;
                resp.RESPONSE_DESCRPTION = ex.Message;
            }

            return resp;
        }

        public RoleMasterRespDTO GetById(int id)
        {
            var resp = new RoleMasterRespDTO();
            try
            {
                var role = _context.RoleMasters.FirstOrDefault(x => x.RoleId == id);
                if (role == null)
                {
                    resp.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    resp.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    return resp;
                }

                resp.RESPONSE_CODE = ConfigClass.SUCCESS;
                resp.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                resp.data = role;
            }
            catch (Exception ex)
            {
                resp.RESPONSE_CODE = ConfigClass.ERROR;
                resp.RESPONSE_DESCRPTION = ex.Message;
            }

            return resp;
        }

        public RoleMasterRespDTO Create(RoleMaster role)
        {
            var resp = new RoleMasterRespDTO();
            try
            {
                role.CreatedDate ??= DateTime.Now;
                _context.RoleMasters.Add(role);
                _context.SaveChanges();

                resp.RESPONSE_CODE = ConfigClass.SUCCESS;
                resp.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                resp.data = role;
            }
            catch (Exception ex)
            {
                resp.RESPONSE_CODE = ConfigClass.ERROR;
                resp.RESPONSE_DESCRPTION = ex.Message;
            }

            return resp;
        }

        public RoleMasterRespDTO Update(int id, RoleMaster role)
        {
            var resp = new RoleMasterRespDTO();
            try
            {
                var existing = _context.RoleMasters.FirstOrDefault(x => x.RoleId == id);
                if (existing == null)
                {
                    resp.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    resp.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    return resp;
                }

                existing.RoleName = role.RoleName;
                existing.RoleCode = role.RoleCode;
                existing.Description = role.Description;
                existing.IsActive = role.IsActive;
                existing.ModifiedBy = role.ModifiedBy;
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

        public RoleMasterRespDTO Delete(int id)
        {
            var resp = new RoleMasterRespDTO();
            try
            {
                var existing = _context.RoleMasters.FirstOrDefault(x => x.RoleId == id);
                if (existing == null)
                {
                    resp.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    resp.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    return resp;
                }

                _context.RoleMasters.Remove(existing);
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

using DataAccess.Core;
using Domain.DBModels;
using Domain.RespDTO.MasterSchemaRespDTO;

namespace DiriAPI.Services.MasterSchemaServices
{
    public class DepartmentService
    {
        private DiriWebPortalContext _diriWebPortalContext;
        private DepartmentRespDTO _deptRespDTO;
        private List<Department> departments;
        public DepartmentService(DiriWebPortalContext diriWebPortalContext)
        {
            _diriWebPortalContext = diriWebPortalContext;
        }

        public DepartmentRespDTO GetAllDepartmentList()
        {
            _deptRespDTO = new();
            departments = new(); 
            try
            {
                departments = _diriWebPortalContext.Departments.Where(x => x.Active == 1).ToList();
                if (departments != null)
                {
                    _deptRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _deptRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _deptRespDTO.lstData = departments;
                }
                else
                {
                    _deptRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _deptRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _deptRespDTO.lstData = null;
                }
            }
            catch (Exception ex)
            {
                _deptRespDTO.RESPONSE_CODE = ConfigClass.ERROR;
                _deptRespDTO.RESPONSE_DESCRPTION = ex.ToString();
                _deptRespDTO.lstData = null;
            }
            return _deptRespDTO;
        }
    }
}

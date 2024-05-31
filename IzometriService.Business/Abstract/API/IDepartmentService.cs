using IzometriService.Core.Models.API.Base;
using IzometriService.Core.Models.API;
using IzometriService.Core.Utilities.Results;
using IzometriService.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IzometriService.Business.Abstract.API
{
    public interface IDepartmentService
    {
        public Task<ApiResult<List<DepartmentModel>>> GetDepartments(OrderSkipTakeReq req);

        public Task<ApiResult<DepartmentModelId>> GetDepartments1(int ID);

        public Task<ApiResult> PostDepartments(BaseDepartmentModel department);

        public Task<ApiResult> PutDepartments(int ID, BaseDepartmentModel department);

        public Task<ApiResult> DeleteDepartments(int ID);
    }
}

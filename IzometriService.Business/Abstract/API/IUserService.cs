using IzometriService.Core.Models.API;
using IzometriService.Core.Models.API.Base;
using IzometriService.Core.Utilities.Results;
using IzometriService.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IzometriService.Business.Abstract.API
{
    public interface IUserService
    {
        public ApiResult<List<UserModel>> GetUsers(bool isActive,OrderSkipTakeReq req);

        public ApiResult<UserModel> GetUsers1(int ID);

        public Task<ApiResult> PostUsers(BaseUserModel user);

        public Task<ApiResult> PutUsers(int ID, BaseUserModel user);

        public Task<ApiResult> DeleteUsers(int ID);
    }
}

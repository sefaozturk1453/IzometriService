using IzometriService.Business.Abstract.API;
using IzometriService.Business.ValidationRules.FluentValidation.API.UserValidation;
using IzometriService.Core.Aspects.Autofac.Transaction;
using IzometriService.Core.Aspects.Autofac.Validation;
using IzometriService.Core.Models.API;
using IzometriService.Core.Models.API.Base;
using IzometriService.Core.Utilities.Results;
using IzometriService.Core.Utilities.Toolkit;
using IzometriService.DataAccess.EntityFramework.UnityOfWork;
using IzometriService.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace IzometriService.Business.Concrete.API
{
    public class UserService : IUserService
    {
        protected readonly IUowBBL _repository;

        public UserService(IUowBBL repository)
        {
            _repository = repository;
        }

        public ApiResult<List<UserModel>> GetUsers(bool isActive, OrderSkipTakeReq req)
        {
            var query = (from userData in _repository.User.GetAllIncluding(x => x.Departments)
                        .Where(x => x.IsActive == isActive)
                         select new UserModel
                         {
                             Id = userData.Id,
                             FirstName = userData.FirstName,
                             LastName = userData.LastName,
                             Email = userData.Email,
                             IsActive = userData.IsActive,
                             DepartmentId = userData.Departments.Id,
                             Department = userData.Departments.Name
                         }
            ).CustomOrderBy(req.OrderBy ?? "Id:desc");

            var result = query.Skip(req.Skip).Take(req.Take).ToList();


            return new ApiResult<List<UserModel>> { Data = result };

        }

        public ApiResult<UserModel> GetUsers1(int ID)
        {
            var query = (from userData in _repository.User.GetAllIncluding(x => x.Departments)
                        .Where(x => x.Id == ID)
                         select new UserModel
                         {
                             Id = userData.Id,
                             FirstName = userData.FirstName,
                             LastName = userData.LastName,
                             Email = userData.Email,
                             IsActive = userData.IsActive,
                             DepartmentId = userData.Departments.Id,
                             Department = userData.Departments.Name
                         }
            );

            var result = query.FirstOrDefault();


            return new ApiResult<UserModel> { Data = result };
        }


        [ValidationAspect(typeof(PostUserValidator))]
        [TransactionScopeAspectAsync]
        public async Task<ApiResult> PostUsers(BaseUserModel user)
        {
            await _repository.User.InsertAsync(new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsActive = true,
                Email = user.Email,
                DepartmentsId = user.DepartmentId
            });

            return new ApiResult();
        }
        [ValidationAspect(typeof(PostUserValidator))]
        [TransactionScopeAspectAsync]
        public async Task<ApiResult> PutUsers(int ID, BaseUserModel user)
        {
            var data = _repository.User.Where(x => x.Id == ID).FirstOrDefault();

            if (data != null)
            {
                data.FirstName = user.FirstName;
                data.LastName = user.LastName;
                data.Email = user.Email;
                data.DepartmentsId = user.DepartmentId;

                _repository.User.Update(data);

                _repository.Commit();

                return new ApiResult();
            }
            else
                return new ApiResult()
                {
                    IsSuccess = false,
                    Message = "Belirtilen Id numarasında değer yoktur!"
                };


        }
        public async Task<ApiResult> DeleteUsers(int ID)
        {
            var data = _repository.User.Where(x => x.Id == ID).FirstOrDefault();

            if (data != null)
            {
                
                data.IsActive = false;

                _repository.User.Update(data);

                _repository.Commit();

                return new ApiResult();
            }
            else
                return new ApiResult()
                {
                    IsSuccess = false,
                    Message = "Belirtilen Id numarasında değer yoktur!"
                };

        }
    }
}

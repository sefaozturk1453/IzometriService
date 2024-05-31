using IzometriService.Business.Abstract.API;
using IzometriService.Core.Models.API;
using IzometriService.Core.Models.API.Base;
using IzometriService.Core.Utilities.Results;
using IzometriService.DataAccess.EntityFramework.UnityOfWork;
using IzometriService.Core.Utilities.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IzometriService.Entities.Concrete;
using IzometriService.Business.ValidationRules.FluentValidation.API.UserValidation;
using IzometriService.Core.Aspects.Autofac.Transaction;
using IzometriService.Core.Aspects.Autofac.Validation;

namespace IzometriService.Business.Concrete.API
{
    public class DepartmentService : IDepartmentService
    {
        protected readonly IUowBBL _repository;

        public DepartmentService(IUowBBL repository)
        {
            _repository = repository;
        }


        public async Task<ApiResult<List<DepartmentModel>>> GetDepartments(OrderSkipTakeReq req)
        {
            var query = (from userData in _repository.Department.GetAll()
                         select new DepartmentModel
                         {
                             Id = userData.Id,
                             Name = userData.Name,
                             IsActive = userData.IsActive
                         }
            ).CustomOrderBy(req.OrderBy ?? "Id:desc");

            var result = query.Skip(req.Skip).Take(req.Take).ToList();

            return new ApiResult<List<DepartmentModel>> { Data = result };
        }

        public async Task<ApiResult<DepartmentModelId>> GetDepartments1(int ID)
        {
            var query = (from userData in _repository.Department.GetAllIncluding(x => x.Users)
                       .Where(x => x.Id == ID)
                         select new DepartmentModelId
                         {
                             Id = userData.Id,
                             Name=userData.Name,
                             IsActive = userData.IsActive
                           
                         }
           );

            var result = query.FirstOrDefault();


            return new ApiResult<DepartmentModelId> { Data = result };
        }


        [ValidationAspect(typeof(PostDepartmentValidator))]
        [TransactionScopeAspectAsync]
        public async Task<ApiResult> PostDepartments(BaseDepartmentModel department)
        {
            await _repository.Department.InsertAsync(new Department
            {
                Name = department.Name,
                IsActive = true,
               
            });

            return new ApiResult();
        }
        [ValidationAspect(typeof(PostDepartmentValidator))]
        [TransactionScopeAspectAsync]
        public async Task<ApiResult> PutDepartments(int ID, BaseDepartmentModel department)
        {
            var data = _repository.Department.Where(x => x.Id == ID).FirstOrDefault();

            if (data != null)
            {
                data.Name = department.Name;
                data.IsActive = department.IsActive;

                _repository.Department.Update(data);

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


        public async Task<ApiResult> DeleteDepartments(int ID)
        {
            var data = _repository.Department.Where(x => x.Id == ID).FirstOrDefault();

            if (data != null)
            {

                data.IsActive = false;

                _repository.Department.Update(data);

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

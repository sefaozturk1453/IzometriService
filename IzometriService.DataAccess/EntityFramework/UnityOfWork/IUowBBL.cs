using IzometriService.Core.Domain.Repositories;
using IzometriService.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace IzometriService.DataAccess.EntityFramework.UnityOfWork
{
    public interface IUowBBL : IDisposable
    {
        IDbContextTransaction BeginTransaction();

        #region ENTITIES

        IRepositoryBase<User> User { get; }
        IRepositoryBase<Department> Department { get; }

        #endregion


        void ExecuteSqlRaw(string sqlCommand);
        Task<int> CommitAsync();
        int Commit();


    }
}

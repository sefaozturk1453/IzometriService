using IzometriService.Core.Domain.Repositories;
using IzometriService.DataAccess.EntityFramework.Base;
using IzometriService.DataAccess.EntityFramework.Context;
using IzometriService.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IzometriService.DataAccess.EntityFramework.UnityOfWork
{
    public class UowBBL : IUowBBL
    {
        public ApplicationDbContext _dbContext { get; }
        public UowBBL(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepositoryBase<User> User => new EfRepositoryBase<User>(_dbContext);

        public IRepositoryBase<Department> Department => new EfRepositoryBase<Department>(_dbContext);

     

        public void ExecuteSqlRaw(string sqlCommand)
        {
            _dbContext.Database.ExecuteSqlRaw(sqlCommand);
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}

using Graduation.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Graduation.DAL.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(object id);
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(object id);
        void Save();
    }
}

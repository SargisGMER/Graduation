using System;
using System.Collections.Generic;
using System.Text;

namespace Graduation.DAL.Interfaces
{
    public interface IBaseDataAccess<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        bool Update(T item);
        bool DeleteById(int id);
        T Create(T item);
    }
}

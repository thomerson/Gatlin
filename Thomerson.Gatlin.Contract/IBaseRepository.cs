using System;
using System.Collections.Generic;
using System.Text;

namespace Thomerson.Gatlin.Contract
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetList();

        T Get(object id);

        bool Update(T t);

        T Insert(T t);

        bool Delete(T t);
    }
}

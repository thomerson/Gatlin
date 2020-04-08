using System;
using System.Collections.Generic;

namespace Thomerson.Gatlin.Contract
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetList();

        T Get(Guid id);

        bool Update(T t);

        T Insert(T t);

        bool Delete(T t);

        Tuple<int, IEnumerable<T>> GetPage(object predicate, int pageindex, int pageSize);
    }
}

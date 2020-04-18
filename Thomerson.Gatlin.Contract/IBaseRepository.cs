using System;
using System.Collections.Generic;

namespace Thomerson.Gatlin.Contract
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetList();

        T Get(Guid id);

        bool Update(T t);

        Guid Insert(T t);

        bool Delete(T t);

        Tuple<int, IEnumerable<T>> PageQuery(object predicate, int pageindex, int pageSize);
    }
}

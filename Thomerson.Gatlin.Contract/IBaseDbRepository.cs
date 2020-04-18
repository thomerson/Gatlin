using Thomerson.Gatlin.Model;
using System;

namespace Thomerson.Gatlin.Contract
{
    public interface IBaseDbRepository<T> : IBaseRepository<T> where T : BaseDbModel
    {
        Guid Insert(T t, string operatorId);
        bool Update(T t, string operatorId);
    }
}

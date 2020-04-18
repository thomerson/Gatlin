using System;
using System.Collections.Generic;
using System.Text;
using Thomerson.Gatlin.Contract;
using Thomerson.Gatlin.Model;

namespace Thomerson.Gatlin.Repository
{
    public class BaseDbRepository<T> : BaseRepository<T>, IBaseDbRepository<T> where T : BaseDbModel
    {
        public Guid Insert(T t, string operatorId)
        {
            t.CreateStamp = DateTime.Now;
            t.CreateBy = operatorId;

            t.LastUpdateStamp = DateTime.Now;
            t.LastUpdateBy = operatorId;

            return base.Insert(t);
        }

        public bool Update(T t, string operatorId)
        {

            t.LastUpdateStamp = DateTime.Now;
            t.LastUpdateBy = operatorId;

            return base.Update(t);
        }
    }
}

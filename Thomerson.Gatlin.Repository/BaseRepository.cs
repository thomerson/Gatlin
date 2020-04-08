using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Thomerson.Gatlin.Contract;
using Thomerson.Gatlin.Model;
using Thomerson.Gatlin.Model.Options;

namespace Thomerson.Gatlin.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected DbOption _dbOption;
        protected IDbConnection _dbConnection;

        public BaseRepository()
        {
            _dbConnection = ConnectionFactory.CreateSqlConnection();
        }

        public bool Delete(T t)
        {
            using (var conn = ConnectionFactory.CreateSqlConnection())
            {
                return conn.Delete(t);
            }
        }

        public T Get(Guid id)
        {
            using (var conn = ConnectionFactory.CreateSqlConnection())
            {
                return conn.Get<T>(id);
            }
        }

        public IEnumerable<T> GetList()
        {
            using (var conn = ConnectionFactory.CreateSqlConnection())
            {
                return conn.GetList<T>();
            }
        }

        public Tuple<int, IEnumerable<T>> GetPage(object predicate, int pageindex, int pageSize)
        {
            using (var conn = ConnectionFactory.CreateSqlConnection())
            {
                var total = conn.Count<T>(predicate);
                var sort = new List<ISort>();
                sort.Add(new Sort() { PropertyName = "Id", Ascending = true });
                return new Tuple<int, IEnumerable<T>>(total, conn.GetPage<T>(predicate, sort, pageindex, pageSize).ToList());
            }
        }

        public T Insert(T t)
        {
            using (var conn = ConnectionFactory.CreateSqlConnection())
            {
                return conn.Insert<T>(t);
            }
        }

        public bool Update(T t)
        {
            using (var conn = ConnectionFactory.CreateSqlConnection())
            {
                return conn.Update<T>(t);
            }
        }
    }
}

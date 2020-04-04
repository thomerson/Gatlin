using DapperExtensions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using Thomerson.Gatlin.Contract;
using Thomerson.Gatlin.Model.Options;

namespace Thomerson.Gatlin.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
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

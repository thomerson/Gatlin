using System;
using System.Data;
using Thomerson.Gatlin.Model;

namespace Thomerson.Gatlin.Repository
{
    public abstract class DapperClient : IDisposable
    {
        public string ConnectionString { get; set; }

        public IDbConnection Connection;

        public void Dispose()
        {
        }
    }
}
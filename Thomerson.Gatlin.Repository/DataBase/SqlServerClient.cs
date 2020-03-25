using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Thomerson.Gatlin.Repository
{
    public class SqlServerClient : DapperClient
    {
        private SqlServerClient() { }

        public SqlServerClient(string connectionString)
        {
            this.ConnectionString = connectionString;
        }


        public IDbConnection CreateSqlConnection()
        {
            var Connection = new System.Data.SqlClient.SqlConnection(ConnectionString);
            Connection.Open();
            return Connection;
        }
        //this.Connection => new System.Data.SqlClient.SqlConnection(ConnectionString);
    }
}

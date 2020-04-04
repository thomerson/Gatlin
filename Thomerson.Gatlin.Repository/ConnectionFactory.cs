using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Thomerson.Gatlin.Core;


namespace Thomerson.Gatlin.Repository
{
    public class ConnectionFactory
    {
        private static readonly string ConnectionString = AppSettings.GetConnectionString("MSConnection");

        public static IDbConnection CreateConnection<T>() where T : IDbConnection, new()
        {
            IDbConnection connection = new T();
            connection.ConnectionString = ConnectionString;//TODO
            connection.Open();
            return connection;
        }

        public static IDbConnection CreateSqlConnection()
        {
            return CreateConnection<SqlConnection>();
        }
    }
}

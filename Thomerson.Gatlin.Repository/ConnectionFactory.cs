using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Thomerson.Gatlin.Repository
{
    public class ConnectionFactory
    {

        public static IDbConnection CreateConnection<T>() where T : IDbConnection, new()
        {
            IDbConnection connection = new T();
            connection.ConnectionString = "";//TODO
            connection.Open();
            return connection;
        }

        public static IDbConnection CreateSqlConnection()
        {
            return CreateConnection<SqlConnection>();
        }

        //public static IDbConnection CreateMySqlConnection(string connectionString)
        //{
        //    return CreateConnection<MySql.Data.MySqlClient.MySqlConnection>(connectionString);
        //}
    }
}

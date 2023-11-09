using System;
using System.Configuration;
using Npgsql;

namespace SayangBayi
{
    public class DbConnection
    {
        private NpgsqlConnection connection;
        public static NpgsqlCommand cmd;
        private string sql = null;

        public DbConnection()
        {
            // Replace the connection string with your PostgreSQL database connection details.
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

            connection = new NpgsqlConnection(connectionString);
        }

        public NpgsqlConnection GetConnection()
        {
            return connection;
        }

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}

using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace monopoly2
{
    public class DatabaseConnection
    {
        private static string connectionString = "Data Source=DESKTOP-91F2TAH;Initial Catalog=MonopolyDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";
        private static SqlConnection connection = new SqlConnection(connectionString);

        public static SqlConnection GetConnection()
        {
            return connection;
        }

        public static void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public static void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
} 
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleRestaurante.base_src.model
{
    static class ConnectionFactory
    {
        static string connectionString = "Host=localhost;Username=postgres;Password=teste123;Database=controle_restaurante";
        static NpgsqlConnection connection = null;

        public static void open()
        {
            if (ConnectionFactory.connection == null)
            {
                ConnectionFactory.connection = new NpgsqlConnection(ConnectionFactory.connectionString);
            }
            ConnectionFactory.connection.Open();
        }

        public static void close()
        {
            if (ConnectionFactory.connection != null && ConnectionFactory.connection.State != System.Data.ConnectionState.Closed)
            {
                ConnectionFactory.connection.Close();
            }
        }

        public static NpgsqlDataReader command(string sql)
        {
            NpgsqlDataReader reader = null;
            try {

                // Retrieve all rows
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, ConnectionFactory.connection))
                {
                    reader = cmd.ExecuteReader();
                }


            } catch (Exception e)
            {
                throw e;
            }

            return reader;
        }
    }
}

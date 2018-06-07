using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace TRS_DAL
{
public class SQL

    {
        private static string connectionString = "Server = studmysql01.fhict.local; Uid=dbi361369;Database=dbi361369;Pwd=Wachtwoord1;SslMode=none;";
        private static bool _connected = false;
        private static MySqlConnection sql;


        private static void _connect()
        {
            sql = new MySqlConnection(connectionString);

            //Make sure Cisco VPN Application is connected to vdi.fhict.nl
            sql.Open();

            _connected = true;
        }

        private static void _disconnect()
        {
            sql.Close();

            sql = null;

            _connected = false;
        }

        public static List<DataRow> ExecuteQuery(string query, List<MySqlParameter> parameters = null)
        {
            if (!_connected)
            {
                _connect();
            }

            using (MySqlCommand command = new MySqlCommand(query, sql))
            {
                if (parameters != null)
                {
                    foreach (MySqlParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    var dt = new DataTable();
                    dt.Load(reader);
                    _disconnect();
                    return dt.AsEnumerable().ToList();
                }
            }

            throw new Exception("Invalid Query");
        }

        public static void ExecuteNonQuery(string query, List<MySqlParameter> parameters = null)
        {
            if (!_connected)
            {
                _connect();
            }

            using (MySqlCommand command = new MySqlCommand(query, sql))
            {
                if (parameters != null)
                {
                    foreach (MySqlParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                
                
                command.ExecuteNonQuery();
                _disconnect();
            }
        }
    }
}

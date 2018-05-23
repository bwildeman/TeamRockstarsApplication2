using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_DAL
{
    public class ConnectionDB
    {
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionStringBuilder.CreateConString());
        }

        public bool ExecuteNonQuery(MySqlCommand inputCommand)
        {
            try
            {
                inputCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}

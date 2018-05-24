using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using TRS_DAL.INTERFACES;
using TRS_Domain.EVENT;

namespace TRS_DAL.CONTEXT
{
    public class EventSqlContext : IEventContext
    {
        private readonly ConnectionDB _connectDb = new ConnectionDB();
        private string _mainQuery;
        private MySqlCommand _mainCommand;

        public List<Data> GetGroupEvents(int groupId)
        {
            List<Data> output = new List<Data>();
            //  Try-Catch for Safety:
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();


                    //  the incomplete query
                    _mainQuery = "SELECT * " +
                                 "FROM event " +
                                 "WHERE GroupID = @groupId";

                    //  build the command
                    _mainCommand = new MySqlCommand(_mainQuery, conn);
                    //defining parameters
                    _mainCommand.Parameters.AddWithValue("@groupId", groupId);
                    //  use the command
                    using (MySqlDataReader reader = _mainCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var eventId = (int)reader["EventID"];
                            var groupID = (int)reader["GroupID"];
                            var name = (string)reader["Name"];
                            var startDate = (DateTime)reader["StartDate"];
                            var endDate = (DateTime)reader["EndDate"];
                            var online = (bool)reader["Online"];
                            var location = (string)reader["Location"];
                            var description = (string)reader["Description"];

                            output.Add(new TRS_Domain.EVENT.Data(eventId, groupID, name, startDate, endDate, online, location, description));
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return output;
        }

        public void CreateGroupEvent(int groupId, string name, DateTime startDate, DateTime endDate, bool online, string location,
            string description)
        {
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();

                    //incomplete query 
                    _mainQuery = "INSERT INTO event " +
                                 "(GroupId, Name, StartDate, EndDate, Online, Location, Description) " +
                                 "VALUES (@groupId, @name, @startDate, @endDate, @online, @location, @description)";

                    //  build the command
                    _mainCommand = new MySqlCommand(_mainQuery, conn);
                    //defining parameters
                    _mainCommand.Parameters.AddWithValue("@groupId", groupId);
                    _mainCommand.Parameters.AddWithValue("@name", name);
                    _mainCommand.Parameters.AddWithValue("@startDate", startDate);
                    _mainCommand.Parameters.AddWithValue("@endDate", endDate);
                    _mainCommand.Parameters.AddWithValue("@online", online);
                    _mainCommand.Parameters.AddWithValue("@location", location);
                    _mainCommand.Parameters.AddWithValue("@description", description);

                    //  use the command
                    _connectDb.ExecuteNonQuery(_mainCommand);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

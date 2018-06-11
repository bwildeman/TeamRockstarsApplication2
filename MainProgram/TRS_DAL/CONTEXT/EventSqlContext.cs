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
                    _mainQuery = "SELECT EventID, UserID, GroupID, Name, StartDate, EndDate, Online, Location_Url, Description " +
                                 "FROM event " +
                                 "WHERE GroupID = @groupId " +
                                 "AND StartDate > UTC_DATE";

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
                            var ownerId = (int) reader["UserID"];
                            var groupID = (int)reader["GroupID"];
                            var name = (string)reader["Name"];
                            var startDate = (DateTime)reader["StartDate"];
                            var endDate = (DateTime)reader["EndDate"];
                            var online = (bool)reader["Online"];
                            var location = (string)reader["Location_Url"];
                            var description = (string)reader["Description"];

                            output.Add(new TRS_Domain.EVENT.Data(eventId, ownerId, groupID, name, startDate, endDate, online, location, description));
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

        public void CreateGroupEvent(int groupId, int ownerId, string name, DateTime startDate, DateTime endDate, bool online, string location,
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
                                 "(GroupId, UserID, Name, StartDate, EndDate, Online, Location_Url, Description) " +
                                 "VALUES (@groupId, @userId, @name, @startDate, @endDate, @online, @location, @description)";

                    //  build the command
                    _mainCommand = new MySqlCommand(_mainQuery, conn);
                    //defining parameters
                    _mainCommand.Parameters.AddWithValue("@groupId", groupId);
                    _mainCommand.Parameters.AddWithValue("@userId", ownerId);
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

        public void AssignUserToEvent(int eventId, int userId)
        {
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();

                    //incomplete query 
                    _mainQuery = "INSERT INTO event_user (EventID, UserID) " +
                                 "VALUES (@eventId, @userId)";

                    //  build the command
                    _mainCommand = new MySqlCommand(_mainQuery, conn);
                    //defining parameters
                    _mainCommand.Parameters.AddWithValue("@eventId", eventId);
                    _mainCommand.Parameters.AddWithValue("@userId", userId);


                    //  use the command
                    _connectDb.ExecuteNonQuery(_mainCommand);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RemoveUserFromEvent(int eventId, int userId)
        {
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();

                    //incomplete query 
                    _mainQuery = "DELETE FROM event_user " +
                                 "WHERE EventID = @eventId " +
                                 "AND UserID = @userId";

                    //  build the command
                    _mainCommand = new MySqlCommand(_mainQuery, conn);
                    //defining parameters
                    _mainCommand.Parameters.AddWithValue("@eventId", eventId);
                    _mainCommand.Parameters.AddWithValue("@userId", userId);


                    //  use the command
                    _connectDb.ExecuteNonQuery(_mainCommand);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public List<TRS_Domain.USER.Data> GetAllEventSignOns(int eventId)
        {
            List<TRS_Domain.USER.Data> output = new List<TRS_Domain.USER.Data>();
            //  Try-Catch for Safety:
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();


                    //  the incomplete query
                    _mainQuery = "SELECT users.UserName, users.UserSurname, users.UserID " +
                                 "FROM users " +
                                 "INNER JOIN event_user ON users.UserID = event_user.UserID " +
                                 "WHERE event_user.EventID = @eventId";

                    //  build the command
                    _mainCommand = new MySqlCommand(_mainQuery, conn);
                    //defining parameters
                    _mainCommand.Parameters.AddWithValue("@eventId", eventId);
                    //  use the command
                    using (MySqlDataReader reader = _mainCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var name = (string)reader["UserName"];
                            var surName = (string)reader["UserSurname"];
                            var id = (int) reader["UserID"];

                            output.Add(new TRS_Domain.USER.Data(id, name, surName));
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

        public void UpdateEvent(Data changedEvent)
        {
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();

                    //incomplete query 
                    _mainQuery = "UPDATE event " +
                                 "SET " +
                                 "Name = @name, StartDate = @startDate, endDate = @endDate, " +
                                 "Online = @online, Location_Url = @location, Description = @description " +
                                 "WHERE EventID = @eventId";

                    //  build the command
                    _mainCommand = new MySqlCommand(_mainQuery, conn);
                    //defining parameters
                    _mainCommand.Parameters.AddWithValue("@eventId", changedEvent.Id);
                    _mainCommand.Parameters.AddWithValue("@name", changedEvent.Name);
                    _mainCommand.Parameters.AddWithValue("@startDate", changedEvent.StartDate);
                    _mainCommand.Parameters.AddWithValue("@endDate", changedEvent.EndDate);
                    _mainCommand.Parameters.AddWithValue("@online", changedEvent.Online);
                    _mainCommand.Parameters.AddWithValue("@location", changedEvent.LocationUrl);
                    _mainCommand.Parameters.AddWithValue("@description", changedEvent.Description);

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

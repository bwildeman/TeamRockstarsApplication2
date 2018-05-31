using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using TRS_DAL.INTERFACES;
using TRS_Domain.CHANNEL;
using TRS_Domain.GROUP;
using TRS_Domain.USER;
using Data = TRS_Domain.GROUP.Data;

namespace TRS_DAL.CONTEXT
{
    public class GroupSqlContext : IGroupContext
    {
        ConnectionDB ConnectDB = new ConnectionDB();
        public string MainQuery;
        public MySqlCommand MainCommand;

        public void AddGroup(string name, string description)
        {
            //Try-Catch for safety:
            try
            {
                using (MySqlConnection Conn = ConnectDB.GetConnection())
                {
                    //  Open Connection:
                    Conn.Open();

                    //  the incomplete query
                    MainQuery =
                        "INSERT INTO `groups`(`GroupName`, `GroupDescription`) " +
                        "VALUES(@Name, @Description)";

                    //  DEFINE the paramaters
                    MySqlParameter param1 = new MySqlParameter();
                    param1.ParameterName = "@Name";
                    param1.Value = name;

                    MySqlParameter param2 = new MySqlParameter();
                    param2.ParameterName = "@Description";
                    param2.Value = description;

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, Conn);

                    //  add the parameters to the command
                    MainCommand.Parameters.Add(param1);
                    MainCommand.Parameters.Add(param2);

                    //  use the command
                    ConnectDB.ExecuteNonQuery(MainCommand);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Data> GetAllGroupInfo()
        {
            //Define output
            List<TRS_Domain.GROUP.Data> output = new List<TRS_Domain.GROUP.Data>();

            //Try-Catch for safety:
            try
            {
                using (MySqlConnection Conn = ConnectDB.GetConnection())
                {
                    //  Open Connection:
                    Conn.Open();

                    //  the incomplete query
                    MainQuery = "SELECT * FROM `groups`";

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, Conn);

                    //  use the command
                    using (MySqlDataReader reader = MainCommand.ExecuteReader())
                    {
                        //  if the query finds a result
                        if (reader.HasRows)
                        {
                            //  read through the result
                            while (reader.Read())
                            {
                                //Retrieve information from the database and put it into a class.
                                output.Add(new TRS_Domain.GROUP.Data(
                                    Convert.ToInt32(reader["GroupID"]),
                                    Convert.ToInt32(reader["GroupLeader"]),
                                    Convert.ToString(reader["GroupName"]),
                                    Convert.ToString(reader["GroupDescription"]),
                                    Convert.ToString(reader["GroupRegion"])
                                    ));
                            }
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

        public Data GetGroupInfo(int groupID)
        {
            //Define output
            TRS_Domain.GROUP.Data output = new TRS_Domain.GROUP.Data();

            //Try-Catch for safety:
            try
            {
                using (MySqlConnection Conn = ConnectDB.GetConnection())
                {
                    //  Open Connection:
                    Conn.Open();

                    //  the incomplete query
                    MainQuery = "SELECT * FROM groups WHERE groups.GroupID = @id";

                    //  DEFINE the paramaters
                    MySqlParameter param1 = new MySqlParameter();
                    param1.ParameterName = "@id";
                    param1.Value = groupID;

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, Conn);

                    //  add the parameters to the command
                    MainCommand.Parameters.Add(param1);

                    //  use the command
                    using (MySqlDataReader reader = MainCommand.ExecuteReader())
                    {
                        //  if the query finds a result
                        if (reader.HasRows)
                        {
                            //  read through the result
                            while (reader.Read())
                            {
                                //Retrieve information from the database and put it into a class.
                                output = new TRS_Domain.GROUP.Data(
                                    Convert.ToInt32(reader["GroupID"]),
                                    Convert.ToInt32(reader["GroupLeader"]),
                                    Convert.ToString(reader["GroupName"]),
                                    Convert.ToString(reader["GroupDescription"]),
                                    Convert.ToString(reader["GroupRegion"])
                                    );
                            }
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

        public List<Data> GetGroups(int userID)
        {
            //Define output:
            List<Data> output = new List<Data>();

            //Try-Catch for safety:
            try
            {
                using (MySqlConnection Conn = ConnectDB.GetConnection())
                {
                    //  Open Connection:
                    Conn.Open();

                    //  the incomplete query
                    MainQuery =
                        "SELECT * " +
                        "FROM groups " +
                        "INNER join group_members on groups.GroupID = group_members.GroupID " +
                        "wHERE group_members.UserID = @id";

                    //  DEFINE the paramaters
                    MySqlParameter param1 = new MySqlParameter();
                    param1.ParameterName = "@id";
                    param1.Value = userID;

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, Conn);

                    //  add the parameters to the command
                    MainCommand.Parameters.Add(param1);

                    //  use the command
                    using (MySqlDataReader reader = MainCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            output.Add(new TRS_Domain.GROUP.Data(
                                    Convert.ToInt32(reader["GroupID"]),
                                    Convert.ToInt32(reader["GroupLeader"]),
                                    Convert.ToString(reader["GroupName"]),
                                    Convert.ToString(reader["GroupDescription"]),
                                    Convert.ToString(reader["GroupRegion"])
                                    )
                            );
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

        public void JoinGroup(TRS_Domain.USER.Data client, TRS_Domain.GROUP.Data group)
        {
            //Try-Catch for safety:
            try
            {
                using (MySqlConnection Conn = ConnectDB.GetConnection())
                {
                    //  Open Connection:
                    Conn.Open();

                    //  the incomplete query
                    MainQuery =
                        "INSERT INTO `group_members` (`GroupID`, `UserID`)" +
                        "VALUES(@GroupId, @ClientId)";


                    //  DEFINE the paramaters
                    MySqlParameter param1 = new MySqlParameter();
                    param1.ParameterName = "@ClientId";
                    param1.Value = client.UserId;

                    MySqlParameter param2 = new MySqlParameter();
                    param2.ParameterName = "@GroupId";
                    param2.Value = group.GroupID;

                    //  build the command
                    MySqlCommand command = new MySqlCommand(MainQuery, Conn);

                    //  add the parameters to the command
                    MainCommand.Parameters.Add(param1);
                    MainCommand.Parameters.Add(param2);

                    //  use the command
                    ConnectDB.ExecuteNonQuery(MainCommand);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateName(int id, string name)
        {
            try
            {
                using (MySqlConnection Conn = ConnectDB.GetConnection())
                {
                    Conn.Open();

                    string Query = "UPDATE `groups` SET `GroupName`= @name WHERE `GroupID` = @id";

                    MySqlParameter param1 = new MySqlParameter();
                    param1.ParameterName = "@name";
                    param1.Value = name;

                    MySqlParameter param2 = new MySqlParameter();
                    param2.ParameterName = "@id";
                    param2.Value = id;

                    MySqlCommand command = new MySqlCommand(Query, Conn);

                    command.Parameters.Add(param1);
                    command.Parameters.Add(param2);

                    ConnectDB.ExecuteNonQuery(command);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateImage(int id, byte[] newImage)
        {
            throw new NotImplementedException();
        }

        public void UpdateRegion(int id, string newRegion)
        {
            try
            {
                using (MySqlConnection Conn = ConnectDB.GetConnection())
                {
                    Conn.Open();

                    string Query = "UPDATE `groups` SET `GroupRegion`= @region WHERE `GroupID` = @id";

                    MySqlParameter param1 = new MySqlParameter();
                    param1.ParameterName = "@region";
                    param1.Value = newRegion;

                    MySqlParameter param2 = new MySqlParameter();
                    param2.ParameterName = "@id";
                    param2.Value = id;

                    MySqlCommand command = new MySqlCommand(Query, Conn);

                    command.Parameters.Add(param1);
                    command.Parameters.Add(param2);

                    ConnectDB.ExecuteNonQuery(command);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateDescription(int id, string newDescription)
        {
            try
            {
                using (MySqlConnection Conn = ConnectDB.GetConnection())
                {
                    Conn.Open();

                    string Query = "UPDATE `groups` SET `GroupDescription`= @description WHERE GroupID = @id";

                    MySqlParameter param1 = new MySqlParameter();
                    param1.ParameterName = "@description";
                    param1.Value = newDescription;

                    MySqlParameter param2 = new MySqlParameter();
                    param2.ParameterName = "@id";
                    param2.Value = id;

                    MySqlCommand command = new MySqlCommand(Query, Conn);

                    command.Parameters.Add(param1);
                    command.Parameters.Add(param2);

                    ConnectDB.ExecuteNonQuery(command);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateStartUpChannel(string selectedChannel)
        {
            throw new NotImplementedException();
        }

        public Channel GetChannel(int GroupId, int Id)
        {
            throw new NotImplementedException();
        }

        public Channel[] GetChannels(int GroupId)
        {
            throw new NotImplementedException();
        }
    }
}

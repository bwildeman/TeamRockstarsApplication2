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
        ConnectionDB _connectDb = new ConnectionDB();
        public string MainQuery;
        public dynamic Procedure;
        public MySqlCommand MainCommand;

        public void AddGroup(int clientID, string name, string description)
        {
            //Try-Catch for safety:
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();

                    //  the incomplete query
                    MainQuery =
                        "INSERT INTO `groups`(`GroupName`, `GroupDescription`, `GroupLeader`, `GroupRegion`)" +
                        "VALUES(@Name, @Description, @clientID, @region);" +
                        "INSERT INTO `group_members` (`GroupID`, `UserID`)" +
                        "VALUES((SELECT LAST_INSERT_ID()), @idclient)";

                    //  DEFINE the paramaters
                    MySqlParameter param1 = new MySqlParameter();
                    param1.ParameterName = "@Name";
                    param1.Value = name;

                    MySqlParameter param2 = new MySqlParameter();
                    param2.ParameterName = "@Description";
                    param2.Value = description;

                    MySqlParameter param3 = new MySqlParameter();
                    param3.ParameterName = "@clientID";
                    param3.Value = clientID;

                    MySqlParameter param4 = new MySqlParameter();
                    param4.ParameterName = "@region";
                    param4.Value = "HardCoded";

                    MySqlParameter param5 = new MySqlParameter();
                    param5.ParameterName = "@idclient";
                    param5.Value = clientID;

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, conn);

                    //  add the parameters to the command
                    MainCommand.Parameters.Add(param1);
                    MainCommand.Parameters.Add(param2);
                    MainCommand.Parameters.Add(param3);
                    MainCommand.Parameters.Add(param4);
                    MainCommand.Parameters.Add(param5);

                    //  use the command
                    _connectDb.ExecuteNonQuery(MainCommand);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool AddGroupWithPic(int clientID, string name, string description, byte[] bitMap)
        {
            //  Define output:
            bool output = false;

            //Try-Catch for safety:
            try
            {
                using (MySqlConnection Conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    Conn.Open();

                    //  the incomplete query
                    MainQuery =
                        "INSERT INTO `groups`(`GroupName`, `GroupDescription`, `GroupImage`,`GroupLeader`,`GroupRegion`) " +
                        "VALUES(@Name, @Description, @Image, @GroupLeader, @GroupRegion); " +
                        "INSERT INTO `group_members` (`GroupID`, `UserID`) " +
                        "VALUES((SELECT LAST_INSERT_ID()), @idclient)"; ;

                    //  DEFINE the paramaters
                    MySqlParameter param1 = new MySqlParameter();
                    param1.ParameterName = "@Name";
                    param1.Value = name;

                    MySqlParameter param2 = new MySqlParameter();
                    param2.ParameterName = "@Description";
                    param2.Value = description;

                    MySqlParameter param3 = new MySqlParameter();
                    param3.ParameterName = "@Image";
                    param3.Value = bitMap;
                    MySqlParameter param4 = new MySqlParameter();
                    param4.ParameterName = "@GroupLeader";
                    param4.Value = clientID;
                    MySqlParameter param5 = new MySqlParameter();
                    param5.ParameterName = "@GroupRegion";
                    param5.Value = "Hardcoded";
                    MySqlParameter param6 = new MySqlParameter();
                    param6.ParameterName = "@idclient";
                    param6.Value = clientID;

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, Conn);

                    //  add the parameters to the command
                    MainCommand.Parameters.Add(param1);
                    MainCommand.Parameters.Add(param2);
                    MainCommand.Parameters.Add(param3);
                    MainCommand.Parameters.Add(param4);
                    MainCommand.Parameters.Add(param5);
                    MainCommand.Parameters.Add(param6);
                    //  use the command
                    output = _connectDb.ExecuteNonQuery(MainCommand);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return output;
        }

        public List<Data> GetAllGroupsThatUserIsNotIn(int UserID)
        {
            //  Define output:
            List<Data> output = new List<Data>();

            try
            {
                using (MySqlConnection Conn = _connectDb.GetConnection())
                {
                    //query
                    Conn.Open();
                    MainQuery =
                        "SELECT * FROM groups where GroupID NOT IN (SELECT GroupID FROM group_members WHERE USerID = @UserID)";

                    // parameters
                    MySqlParameter param1 = new MySqlParameter();
                    param1.ParameterName = "@UserID";
                    param1.Value = UserID;

                    // build com
                    MainCommand = new MySqlCommand(MainQuery, Conn);

                    //  add the parameters to the command
                    MainCommand.Parameters.Add(param1);
                    // using comm
                    using (MySqlDataReader reader = MainCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["GroupID"]);
                            string Name = Convert.ToString(reader["GroupName"]);
                            string Description =Convert.ToString(reader["GroupDescription"]);
                            byte[] img = null;
                            if (reader["GroupImage"] != DBNull.Value)
                            {
                                img = (byte[])(reader["GroupImage"]);
                            }
                            output.Add((new Data(id,Name,Description,img)));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return output;
        }

        public void AddGroup(string name, string description)
        {
            //Try-Catch for safety:
            try
            {
                using (MySqlConnection Conn = _connectDb.GetConnection())
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
                    _connectDb.ExecuteNonQuery(MainCommand);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<TRS_Domain.GROUP.Data> GetAllGroupInfo()
        {
            //Define output
            List<TRS_Domain.GROUP.Data> output = new List<TRS_Domain.GROUP.Data>();

            //Try-Catch for safety:
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();

                    //  the incomplete query
                    MainQuery = "SELECT * FROM `groups`";

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, conn);

                    //  use the command
                    using (MySqlDataReader reader = MainCommand.ExecuteReader())
                    {
                        //  if the query finds a result
                        if (reader.HasRows)
                        {
                            //  read through the result
                            while (reader.Read())
                            {
                                byte[] img = null;
                                if (reader["GroupImage"] != DBNull.Value)
                                {
                                    img = (byte[])(reader["GroupImage"]);
                                }
                                //Retrieve information from the database and put it into a class.
                                output.Add(new TRS_Domain.GROUP.Data(
                                    Convert.ToInt32(reader["GroupID"]),
                                    Convert.ToString(reader["GroupName"]),
                                    Convert.ToString(reader["GroupDescription"]),
                                    img

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

        public TRS_Domain.GROUP.Data GetGroupInfo(int groupId)
        {
            //Define output
            TRS_Domain.GROUP.Data output = new TRS_Domain.GROUP.Data();

            //Try-Catch for safety:
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();

                    //  the incomplete query
                    MainQuery = "SELECT * FROM `group` WHERE `GroupID` = @id";

                    //  DEFINE the paramaters
                    MySqlParameter param1 = new MySqlParameter();
                    param1.ParameterName = "@id";
                    param1.Value = groupId;

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, conn);

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
                                byte[] img = null;
                                if (reader["GroupImage"] != DBNull.Value)
                                {
                                    img = (byte[])(reader["GroupImage"]);
                                }
                                //Retrieve information from the database and put it into a class.
                                output = new TRS_Domain.GROUP.Data(
                                    Convert.ToInt32(reader["GroupID"]),
                                    Convert.ToString(reader["GroupName"]),
                                    Convert.ToString(reader["GroupDescription"]), img
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

        public List<TRS_Domain.GROUP.Data> GetGroups(int userId)
        {
            //Define output:
            List<TRS_Domain.GROUP.Data> output = new List<TRS_Domain.GROUP.Data>();

            //Try-Catch for safety:
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();

                    //  the incomplete query
                    MainQuery =
                        "SELECT groups.GroupID, GroupName, GroupDescription, GroupImage " +
                        "FROM groups " +
                        "INNER join group_members on groups.GroupID = group_members.GroupID " +
                        "WHERE group_members.UserID = @id";

                    //  DEFINE the paramaters
                    MySqlParameter param1 = new MySqlParameter();
                    param1.ParameterName = "@id";
                    param1.Value = userId;

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, conn);

                    //  add the parameters to the command
                    MainCommand.Parameters.Add(param1);

                    //  use the command
                    using (MySqlDataReader reader = MainCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int groupId = Convert.ToInt32(reader["GroupID"]);
                            string groupName = Convert.ToString(reader["GroupName"]);
                            string groupDescription = Convert.ToString(reader["GroupDescription"]);
                            byte[] img = null;
                            if (reader["GroupImage"] != DBNull.Value)
                            {
                                img = (byte[])(reader["GroupImage"]);
                            }
                            output.Add(new TRS_Domain.GROUP.Data(groupId, groupName, groupDescription, img));
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

        public Channel GetChannel(int GroupId, int Id)
        {
            throw new NotImplementedException();
        }

        public Channel[] GetChannels(int GroupId)
        {
            throw new NotImplementedException();
        }

        public void UpdateName(int id, string name)
        {
            try
            {
                using (MySqlConnection Conn = _connectDb.GetConnection())
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

                    _connectDb.ExecuteNonQuery(command);
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
                using (MySqlConnection Conn = _connectDb.GetConnection())
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

                    _connectDb.ExecuteNonQuery(command);
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
                using (MySqlConnection Conn = _connectDb.GetConnection())
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

                    _connectDb.ExecuteNonQuery(command);
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

        void IGroupContext.JoinGroup(TRS_Domain.USER.Data client, Data myGroup)
        {
            //Try-Catch for safety:
            try
            {
                using (MySqlConnection Conn = _connectDb.GetConnection())
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
                    param2.Value = myGroup.GroupId;

                    //  build the command
                    MySqlCommand command = new MySqlCommand(MainQuery, Conn);

                    //  add the parameters to the command
                    MainCommand.Parameters.Add(param1);
                    MainCommand.Parameters.Add(param2);

                    //  use the command
                    _connectDb.ExecuteNonQuery(MainCommand);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool JoinGroup(TRS_Domain.USER.Data client, TRS_Domain.GROUP.Data myGroup)
        {
            //  Define output:
            bool output = false;

            //Try-Catch for safety:
            try
            {
                using (MySqlConnection Conn = _connectDb.GetConnection())
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
                    param2.Value = myGroup.GroupId;

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, Conn);

                    //  add the parameters to the command
                    MainCommand.Parameters.Add(param1);
                    MainCommand.Parameters.Add(param2);

                    //  use the command
                    output = _connectDb.ExecuteNonQuery(MainCommand);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return output;
        }
    }
}

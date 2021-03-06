﻿using MySql.Data.MySqlClient;
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

        public bool AddGroup(TRS_Domain.USER.Data client, string name, string description, string region)
        {
            //  Define output:
            bool output = false;
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
                    param3.Value = client.UserId;

                    MySqlParameter param4 = new MySqlParameter();
                    param4.ParameterName = "@region";
                    param4.Value = region;

                    MySqlParameter param5 = new MySqlParameter();
                    param5.ParameterName = "@idclient";
                    param5.Value = client.UserId;

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, conn);

                    //  add the parameters to the command
                    MainCommand.Parameters.Add(param1);
                    MainCommand.Parameters.Add(param2);
                    MainCommand.Parameters.Add(param3);
                    MainCommand.Parameters.Add(param4);
                    MainCommand.Parameters.Add(param5);

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

        public bool AddGroup(TRS_Domain.USER.Data client, string name, string description, byte[] bitMap, string region)
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
                        "VALUES((SELECT LAST_INSERT_ID()), @idclient)";
                    ;

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
                    param4.Value = client.UserId;

                    MySqlParameter param5 = new MySqlParameter();
                    param5.ParameterName = "@GroupRegion";
                    param5.Value = region;

                    MySqlParameter param6 = new MySqlParameter();
                    param6.ParameterName = "@idclient";
                    param6.Value = client.UserId;

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
                            string Description = Convert.ToString(reader["GroupDescription"]);
                            byte[] img = null;
                            if (reader["GroupImage"] != DBNull.Value)
                            {
                                img = (byte[]) (reader["GroupImage"]);
                            }

                            int groupleader = Convert.ToInt32(reader["GroupLeader"]);
                            Convert.ToString(reader["GroupRegion"]);
                            string region =Convert.ToString(reader["GroupRegion"]);
                            output.Add((new Data(id, Name, Description, img,groupleader, region)));
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
                                    img = (byte[]) (reader["GroupImage"]);
                                }

                                //Retrieve information from the database and put it into a class.
                                output.Add(new TRS_Domain.GROUP.Data(
                                    Convert.ToInt32(reader["GroupID"]),
                                    Convert.ToString(reader["GroupName"]),
                                    Convert.ToString(reader["GroupDescription"]),
                                    img,
                                    Convert.ToInt32(reader["GroupLeader"]),
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
                    MainQuery = "SELECT * FROM `groups` WHERE `GroupID` = @id";

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
                                    img = (byte[]) (reader["GroupImage"]);
                                }

                                //Retrieve information from the database and put it into a class.
                                output = new TRS_Domain.GROUP.Data(
                                    Convert.ToInt32(reader["GroupID"]),
                                    Convert.ToString(reader["GroupName"]),
                                    Convert.ToString(reader["GroupDescription"]), img,
                                    Convert.ToInt32(reader["GroupLeader"]),
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
                        "SELECT groups.GroupID, GroupName, GroupDescription, GroupImage,GroupLeader, GroupRegion " +
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
                                img = (byte[]) (reader["GroupImage"]);
                            }

                            int groupleader = Convert.ToInt32(reader["GroupLeader"]);
                            string region =Convert.ToString(reader["GroupRegion"]);
                            output.Add(new TRS_Domain.GROUP.Data(groupId, groupName, groupDescription, img,groupleader, region));
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

            using (MySqlConnection Conn = _connectDb.GetConnection())
            {
                Conn.Open();

                string Query = "UPDATE `groups` SET `GroupImage` = @Img WHERE `GroupID` = @GroupID";

                MySqlParameter param1 = new MySqlParameter();
                param1.ParameterName = "@Img";
                param1.Value = newImage;

                MySqlParameter param2 = new MySqlParameter();
                param2.ParameterName = "@GroupID";
                param2.Value = id;

                MySqlCommand command = new MySqlCommand(Query, Conn);

                command.Parameters.Add(param1);
                command.Parameters.Add(param2);

                _connectDb.ExecuteNonQuery(command);
            }
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

        public bool JoinGroup(TRS_Domain.USER.Data client, Data myGroup)
        {
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

        public void LeaveGroup(int userID, int GroupID)
        {
            try
            {
                using (MySqlConnection Conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    Conn.Open();

                    //  the incomplete query
                    MainQuery =
                        "DELETE FROM `group_members` WHERE GroupID= @GroupID AND UserID = @UserID";


                    //  DEFINE the paramaters
                    MySqlParameter param1 = new MySqlParameter();
                    param1.ParameterName = "@UserID";
                    param1.Value = userID;

                    MySqlParameter param2 = new MySqlParameter();
                    param2.ParameterName = "@GroupID";
                    param2.Value = GroupID;

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

    }
}

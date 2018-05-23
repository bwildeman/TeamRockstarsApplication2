using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using TRS_Domain;

namespace TRS_DAL
{
    public static class DbConnect
    {
        static private string _connectionString;
        static private string _database = "dbi361369";
        static private string _password = "Wachtwoord1";
        static private string _server = "studmysql01.fhict.local";
        static private string _uid = "dbi361369";
        static private MySqlConnection _connection;

        static private bool CloseConn()
        {
            try { if (_connection.State == System.Data.ConnectionState.Open) { _connection.Close(); }; return true; }
            catch { return false; }
        }

        /// <summary>
        /// Check function that returns true or false, depending on what the input command is.
        /// </summary>
        /// <returns></returns>
        static private bool ExecuteCheck(MySqlCommand inputCommand)
        {
            //Define output
            bool output = false;
            try
            {
                //use the command
                using (MySqlDataReader reader = inputCommand.ExecuteReader())
                {
                    //  if the query finds a result
                    if (reader.HasRows)
                    {
                        output = true;
                    }
                    else
                    {
                        output = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return output;
        }

        /// <summary>
        /// Seperation of the execute query into the database.
        /// </summary>
        /// <param name="inputCommand"></param>
        static private void ExecuteInsert(MySqlCommand inputCommand)
        {
            //use try so the code doesn`t crash
            try
            {
                inputCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void JoinGroup(TRS_Domain.USER.Data client, TRS_Domain.GROUP.Data myGroup)
        {
            //use try so the code doesn`t crash
            try
            {
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }

                //  the incomplete query
                string query =
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
                MySqlCommand command = new MySqlCommand(query, _connection);

                //  add the parameters to the command
                command.Parameters.Add(param1);
                command.Parameters.Add(param2);

                //  use the command
                ExecuteInsert(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _connection.Close();
        }

        /// <summary>
        /// Add Message to the database, use MessageAdded Function for a check up.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="group"></param>
        /// <param name="message"></param>
        /// <param name="time"></param>
        static public void AddMessage(int user, int chat, string message, DateTime time)
        {
            //use try so the code doesn`t crash
            try
            {
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }
                //  the incomplete query
                string query = "INSERT INTO `chatmessages`(`ChatID`, `UserID`, `Message`, `SendDate`) VALUES(@chatID, @userID, @message, @sendDate)";

                //  DEFINE the paramaters
                MySqlParameter param1 = new MySqlParameter();
                param1.ParameterName = "@chatID";
                param1.Value = chat;

                MySqlParameter param2 = new MySqlParameter();
                param2.ParameterName = "@userID";
                param2.Value = user;

                MySqlParameter param3 = new MySqlParameter();
                param3.ParameterName = "@message";
                param3.Value = message;

                MySqlParameter param4 = new MySqlParameter();
                param4.ParameterName = "@sendDate";
                param4.Value = time;

                //  build the command
                MySqlCommand command = new MySqlCommand(query, _connection);

                //  add the parameters to the command
                command.Parameters.Add(param1);
                command.Parameters.Add(param2);
                command.Parameters.Add(param3);
                command.Parameters.Add(param4);

                //  use the command
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _connection.Close();
        }

        public static void AddChat(int groupId, string name, string description)
        {
            //use try so the code doesn`t crash
            try
            {
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }

                //  the incomplete query
                string query =
                    "INSERT INTO `chats` (`GroupID`,`ChatName`, `ChatDescription`) " +
                    "VALUES(@GroupID, @Name, @Description)";

                //  DEFINE the paramaters
                MySqlParameter param1 = new MySqlParameter();
                param1.ParameterName = "@GroupID";
                param1.Value = groupId;

                MySqlParameter param2 = new MySqlParameter();
                param2.ParameterName = "@Name";
                param2.Value = name;

                MySqlParameter param3 = new MySqlParameter();
                param3.ParameterName = "@Description";
                param3.Value = description;

                //  build the command
                MySqlCommand command = new MySqlCommand(query, _connection);

                //  add the parameters to the command
                command.Parameters.Add(param1);
                command.Parameters.Add(param2);
                command.Parameters.Add(param3);

                //  use the command
                ExecuteInsert(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _connection.Close();
        }


        public static void AddGroup(string name, string description)
        {
            //use try so the code doesn`t crash
            try
            {
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }

                //  the incomplete query
                string query =
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
                MySqlCommand command = new MySqlCommand(query, _connection);

                //  add the parameters to the command
                command.Parameters.Add(param1);
                command.Parameters.Add(param2);

                //  use the command
                ExecuteInsert(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _connection.Close();
        }

        /// <summary>
        /// Using input's to try and find an account and the right password combination. Returns UserID or -1 of false.
        /// </summary>
        /// <summary>
        /// Adds user into user table into the database, input should be checked before, returns if user is added succesfully.
        /// </summary>
        static public bool AddUser(string name, string surname, string email, string region, string department, string phonenumber, string quote, string portfolio, string photolink, string adres, int gender, int type, DateTime dob)
        {
            //TODO Add [IF NOT EXIST] for a email check-up

            //Define output:
            bool output = false;
            //use try so the code doesn`t crash
            try
            {
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }

                //  the incomplete query
                string query = "INSERT INTO users (Online, UserName, UserSurname, UserEmail, UserRegion, UserDepartment, UserPhoneNumber, UserQuote, UserPortfolio, UserPhotoLink, UserAdres, UserGender, UserType, UserDOB) VALUES (@Status, @name, @surname, @email, @region, @department, @phonenumber, @quote, @portfolio, @photolink, @adres, @gender, @type, @dob)";

                //  DEFINE the paramaters
                MySqlParameter param1 = new MySqlParameter();
                param1.ParameterName = "@name";
                param1.Value = name;

                MySqlParameter param2 = new MySqlParameter();
                param2.ParameterName = "@surname";
                param2.Value = surname;

                MySqlParameter param3 = new MySqlParameter();
                param3.ParameterName = "@email";
                param3.Value = email;

                MySqlParameter param4 = new MySqlParameter();
                param4.ParameterName = "@region";
                param4.Value = region;

                MySqlParameter param5 = new MySqlParameter();
                param5.ParameterName = "@department";
                param5.Value = department;

                MySqlParameter param6 = new MySqlParameter();
                param6.ParameterName = "@phonenumber";
                param6.Value = phonenumber;

                MySqlParameter param7 = new MySqlParameter();
                param7.ParameterName = "@quote";
                param7.Value = quote;

                MySqlParameter param8 = new MySqlParameter();
                param8.ParameterName = "@portfolio";
                param8.Value = portfolio;

                MySqlParameter param9 = new MySqlParameter();
                param9.ParameterName = "@photolink";
                param9.Value = photolink;

                MySqlParameter param10 = new MySqlParameter();
                param10.ParameterName = "@adres";
                param10.Value = adres;

                MySqlParameter param11 = new MySqlParameter();
                param11.ParameterName = "@gender";
                param11.Value = gender;

                MySqlParameter param12 = new MySqlParameter();
                param12.ParameterName = "@type";
                param12.Value = type;

                MySqlParameter param13 = new MySqlParameter();
                param13.ParameterName = "@dob";
                param13.Value = dob;

                //  build the command
                MySqlCommand command = new MySqlCommand(query, _connection);

                //  add the parameters to the command
                command.Parameters.Add(param1);
                command.Parameters.Add(param2);
                command.Parameters.Add(param3);
                command.Parameters.Add(param4);
                command.Parameters.Add(param5);
                command.Parameters.Add(param6);
                command.Parameters.Add(param7);
                command.Parameters.Add(param8);
                command.Parameters.Add(param9);
                command.Parameters.Add(param10);
                command.Parameters.Add(param11);
                command.Parameters.Add(param12);
                command.Parameters.Add(param13);

                //  use the command
                ExecuteInsert(command);

                //  Create second incomplete query
                string checkQuery = "SELECT COUNT(UserEmail) FROM users WHERE UserEmail = @email";

                //  build the command
                command = new MySqlCommand(checkQuery, _connection);

                //  add the parameters to the command
                command.Parameters.Add(param3);

                //  use the command
                output = ExecuteCheck(command);

                return output;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _connection.Close();
            return output;
        }

        static public List<TRS_Domain.CHAT.Data> GetAllChats(int groupId)
        {
            //  Define output:
            List<TRS_Domain.CHAT.Data> output = new List<TRS_Domain.CHAT.Data>();

            //  Try-Catch for safety
            try
            {
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }
                //  the incomplete query
                string query = "SELECT * FROM `chats` WHERE GroupID = @id";

                //  DEFINE the paramaters
                MySqlParameter param1 = new MySqlParameter();
                param1.ParameterName = "@id";
                param1.Value = groupId;

                //  build the command
                MySqlCommand command = new MySqlCommand(query, _connection);

                //  add the parameters to the command
                command.Parameters.Add(param1);

                //  use the command
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    //  if the query finds a result
                    if (reader.HasRows)
                    {
                        //  read through the result
                        while (reader.Read())
                        {
                            //Retrieve information from the database and put it into a class.
                            int chatId = Convert.ToInt32(reader["ChatID"]);
                            string chatName = Convert.ToString(reader["ChatName"]);
                            string chatDescription = Convert.ToString(reader["ChatDescription"]);
                            output.Add(new TRS_Domain.CHAT.Data(chatId, chatName, chatDescription));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _connection.Close();
            return output;
        }

        /// <summary>
        /// Gets all users that are in the database, returns list with User Class, needs to be updated 24-2-2018
        /// </summary>
        /// <returns></returns>
        static public List<TRS_Domain.USER.Data> GetAllUsers()
        {
            //Define output:
            List<TRS_Domain.USER.Data> output = new List<TRS_Domain.USER.Data>();
            try
            {
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }
                //  the incomplete query
                string query = "SELECT * FROM users ORDER BY UserSurname";

                //  DEFINE the paramaters

                //  build the command
                MySqlCommand command = new MySqlCommand(query, _connection);

                //  add the parameters to the command

                //  use the command
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int userId = Convert.ToInt32(reader["UserID"]);
                        string name = Convert.ToString(reader["UserName"]);
                        string surname = Convert.ToString(reader["UserSurname"]);
                        string email = Convert.ToString(reader["UserEmail"]);
                        string region = Convert.ToString(reader["UserRegion"]);
                        string department = Convert.ToString(reader["UserDepartment"]);
                        string phonenumber = Convert.ToString(reader["UserPhoneNumber"]);
                        string quote = Convert.ToString(reader["UserQuote"]);
                        string portfolio = Convert.ToString(reader["UserPortfolio"]);
                        string photolink = Convert.ToString(reader["UserPhotoLink"]);
                        string adres = Convert.ToString(reader["UserAdres"]);
                        int gender = Convert.ToInt32(reader["UserGender"]);
                        int type = Convert.ToInt32(reader["UserType"]);
                        DateTime dob = Convert.ToDateTime(reader["UserDOB"]);
                        byte[] img = null;
                        if (reader["UserProfilePicture"] != DBNull.Value)
                        {
                            img = (byte[])(reader["UserProfilePicture"]);
                        }
                        output.Add(new TRS_Domain.USER.Data(userId, name, surname, email, region, department, phonenumber, quote, portfolio, photolink, adres, gender, type, dob, img));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _connection.Close();
            return output;
        }

        /// <summary>
        /// Returns a list with only the names of all members in the users table.
        /// </summary>
        /// <returns></returns>
        static public List<TRS_Domain.USER.Data> GetAllUsersName()
        {
            //Define output:
            List<TRS_Domain.USER.Data> output = new List<TRS_Domain.USER.Data>();
            try
            {
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }
                //  the incomplete query
                string query = "SELECT UserID, UserName, UserSurname FROM users ORDER BY UserSurname";

                //  DEFINE the paramaters

                //  build the command
                MySqlCommand command = new MySqlCommand(query, _connection);

                //  add the parameters to the command

                //  use the command
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //  Save values:
                        int userId = Convert.ToInt32(reader["UserID"]);
                        string name = Convert.ToString(reader["UserName"]);
                        string surname = Convert.ToString(reader["UserSurname"]);

                        //  Save to output:
                        output.Add(new TRS_Domain.USER.Data(userId, name, surname));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _connection.Close();
            return output;
        }

        /// <summary>
        /// Returns Group class with all the information from the database.
        /// </summary>
        static public TRS_Domain.GROUP.Data GetGroupInfo(int groupId)
        {
            //Define output
            TRS_Domain.GROUP.Data output = new TRS_Domain.GROUP.Data();

            //use try so the code doesn`t crash
            try
            {
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }
                //  the incomplete query
                string query = "SELECT * FROM `group` WHERE `GroupID` = @id";

                //  DEFINE the paramaters
                MySqlParameter param1 = new MySqlParameter();
                param1.ParameterName = "@id";
                param1.Value = groupId;

                //  build the command
                MySqlCommand command = new MySqlCommand(query, _connection);

                //  add the parameters to the command
                command.Parameters.Add(param1);

                //  use the command
                using (MySqlDataReader reader = command.ExecuteReader())
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
                                Convert.ToString(reader["GroupName"]),
                                Convert.ToString(reader["GroupDescription"])
                                );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _connection.Close();
            return output;
        }

        /// <summary>
        /// Returns all the groups and their information
        /// </summary>
        /// <returns></returns>
        static public List<TRS_Domain.GROUP.Data> GetAllGroupInfo()
        {
            //Define output
            List<TRS_Domain.GROUP.Data> output = new List<TRS_Domain.GROUP.Data>();

            //use try so the code doesn`t crash
            try
            {
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }
                //  the incomplete query
                string query = "SELECT * FROM `groups`";

                //  build the command
                MySqlCommand command = new MySqlCommand(query, _connection);

                //  use the command
                using (MySqlDataReader reader = command.ExecuteReader())
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
                                Convert.ToString(reader["GroupName"]),
                                Convert.ToString(reader["GroupDescription"])
                                ));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _connection.Close();
            return output;
        }

        /// <summary>
        /// Returns all Groups that are linked to specific UserID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        static public List<TRS_Domain.GROUP.Data> GetGroups(int userId)
        {
            //Define output:
            List<TRS_Domain.GROUP.Data> output = new List<TRS_Domain.GROUP.Data>();

            //use try so the code doesn`t crash
            try
            {
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }

                //  the incomplete query
                string query =
                    "SELECT groups.GroupID, GroupName, GroupDescription " +
                    "FROM groups " +
                    "INNER join group_members on groups.GroupID = group_members.GroupID " +
                    "wHERE group_members.UserID = @id";

                //  DEFINE the paramaters
                MySqlParameter param1 = new MySqlParameter();
                param1.ParameterName = "@id";
                param1.Value = userId;

                //  build the command
                MySqlCommand command = new MySqlCommand(query, _connection);

                //  add the parameters to the command
                command.Parameters.Add(param1);

                //  use the command
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int groupId = Convert.ToInt32(reader["GroupID"]);
                        string groupName = Convert.ToString(reader["GroupName"]);
                        string groupDescription = Convert.ToString(reader["GroupDescription"]);
                        output.Add(new TRS_Domain.GROUP.Data(groupId, groupName, groupDescription));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _connection.Close();
            return output;
        }

        /// <summary>
        /// Get all chat messages for one specific chat group, insert ChatID.
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        static public List<TRS_Domain.CHAT.Message> GetMessages(int chatId)
        {
            //Define output:
            List<TRS_Domain.CHAT.Message> output = new List<TRS_Domain.CHAT.Message>();

            //use try so the code doesn`t crash
            try
            {
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }
                //  the incomplete query
                string query = "SELECT `MessageID`, `ChatID`, `Message`, `SendDate`, users.UserName, users.UserSurname FROM `chatmessages` INNER JOIN users ON  users.UserID = chatmessages.UserID WHERE ChatID = @id ORDER BY SendDate"; 
                //string query = "SELECT * FROM chatmessages WHERE ChatID = @id ORDER BY SendDate"; //TODO make innerjoin  SELECT name, surname innerjoin userid (users, chattable)

                //  DEFINE the paramaters
                MySqlParameter param1 = new MySqlParameter();
                param1.ParameterName = "@id";
                param1.Value = chatId;

                //  build the command
                MySqlCommand command = new MySqlCommand(query, _connection);

                //  add the parameters to the command
                command.Parameters.Add(param1);

                //  use the command
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = Convert.ToString(reader["UserName"]);
                        string surname = Convert.ToString(reader["UserSurname"]);
                        string message = Convert.ToString(reader["Message"]);
                        string sendDate = Convert.ToDateTime(reader["SendDate"]).ToShortDateString();
                        output.Add(new TRS_Domain.CHAT.Message($"{name} {surname}", message, sendDate));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _connection.Close();
            return output;
        }

        /// <summary>
        /// Get username after inserting the given UserID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        static public string GetUserName(int id)
        {
            //Define output
            string output = "";

            //use try so the code doesn`t crash
            try
            {
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }
                //  the incomplete query
                string query = "SELECT UserName, UserSurname FROM users WHERE UserID = @id";

                //  DEFINE the paramaters
                MySqlParameter param1 = new MySqlParameter();
                param1.ParameterName = "@id";
                param1.Value = id;
                //  build the command
                MySqlCommand command = new MySqlCommand(query, _connection);

                //  add the parameters to the command
                command.Parameters.Add(param1);

                //  use the command
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    //  if the query finds a result
                    if (reader.HasRows)
                    {
                        //  read through the result
                        while (reader.Read())
                        {
                            string name = Convert.ToString(reader["UserName"]);
                            string surname = Convert.ToString(reader["UserSurname"]);
                            output = name + " " + surname;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _connection.Close();
            return output;
        }

        static public TRS_Domain.USER.Data GetUser(int id)
        {
            //Define output:
            TRS_Domain.USER.Data output = new TRS_Domain.USER.Data();

            //use try so the code doesn`t crash
            try
            {
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }
                //  the incomplete query
                string query = "Select * FROM users WHERE UserID = @id";

                //  DEFINE the paramaters
                MySqlParameter param1 = new MySqlParameter();
                param1.ParameterName = "@id";
                param1.Value = id;

                //  build the command
                MySqlCommand command = new MySqlCommand(query, _connection);

                //  add the parameters to the command
                command.Parameters.Add(param1);

                //  use the command
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    //  if the query finds a result
                    if (reader.HasRows)
                    {

                        //  read through the result
                        while (reader.Read())
                        {
                            //Save all info from user
                            int userId = Convert.ToInt32(reader["UserID"]);
                            string name = Convert.ToString(reader["UserName"]);
                            string surname = Convert.ToString(reader["UserSurname"]);
                            string email = Convert.ToString(reader["UserEmail"]);
                            string region = Convert.ToString(reader["UserRegion"]);
                            string department = Convert.ToString(reader["UserDepartment"]);
                            string phonenumber = Convert.ToString(reader["UserPhoneNumber"]);
                            string quote = Convert.ToString(reader["UserQuote"]);
                            string portfolio = Convert.ToString(reader["UserPortfolio"]);
                            string photolink = Convert.ToString(reader["UserPhotoLink"]);
                            string adres = Convert.ToString(reader["UserAdres"]);
                            int gender = Convert.ToInt32(reader["UserGender"]);
                            int type = Convert.ToInt32(reader["UserType"]);
                            DateTime dob = Convert.ToDateTime(reader["UserDOB"]);
                            byte[] img = null;
                            if (reader["UserProfilePicture"] != DBNull.Value)
                            {
                                img = (byte[])(reader["UserProfilePicture"]);
                            }
                            output = new TRS_Domain.USER.Data(userId, name, surname, email, region, department, phonenumber, quote, portfolio, photolink, adres, gender, type, dob, img);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            CloseConn();
            return output;
        }

        static public int Login(string email, string oldpassword)
        {
            //Define output:
            int output = 0;

            //Change input:
            int password = oldpassword.GetHashCode();

            //use try so the code doesn`t crash
            try
            {
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }
                //  the incomplete query
                string query = "Select UserID FROM users WHERE UserEmail = @email AND UserPassword = @password";

                //  DEFINE the paramaters
                MySqlParameter param1 = new MySqlParameter();
                param1.ParameterName = "@email";
                param1.Value = email;

                MySqlParameter param2 = new MySqlParameter();
                param2.ParameterName = "@password";
                param2.Value = password;

                //  build the command
                MySqlCommand command = new MySqlCommand(query, _connection);

                //  add the parameters to the command
                command.Parameters.Add(param1);
                command.Parameters.Add(param2);

                //  use the command
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    //  if the query finds a result
                    if (reader.HasRows)
                    {
                        //  read through the result
                        while (reader.Read())
                        {
                            //  check the output if its valid
                            if (reader["UserID"] != DBNull.Value)
                            {
                                //  read as an array
                                output = Convert.ToInt32(reader["UserID"]);
                            }
                        }
                    }
                    else
                    {
                        output = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _connection.Close();

            return output;
        }

        /// <summary>
        /// Check if messsage has been added into the database WORK IN PROGRESS (FATAL ERROR...).
        /// </summary>
        /// <param name="message"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        static public bool MessageAdded(string message, DateTime time)
        {
            //Define output
            bool output = false;
            //use try so the code doesn`t crash
            try
            {
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }
                //  the incomplete query
                string checkQuery = "SELECT COUNT(UserID) FROM user WHERE ChatMessage = @message AND SendDate = @date";

                //  DEFINE the paramaters
                MySqlParameter param5 = new MySqlParameter();
                param5.ParameterName = "@message";
                param5.Value = message;

                MySqlParameter param6 = new MySqlParameter();
                param5.ParameterName = "@date";
                param5.Value = time;

                //  build the command
                MySqlCommand command = new MySqlCommand(checkQuery, _connection);

                //  add the parameters to the command
                command.Parameters.Add(param5);
                command.Parameters.Add(param6);

                //  use the command
                output = ExecuteCheck(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _connection.Close();
            return output;
        }

        static public void SetupConnection()
        {
            _connectionString = "SERVER=" + _server + ";" + "DATABASE=" + _database + ";" + "UID=" + _uid + ";" + "PASSWORD=" + _password + ";";
            _connection = new MySqlConnection(_connectionString);
        }

        static public List<TRS_Domain.USER.Data> GetAllUsers(int clientId)
        {
            //Define output:
            List<TRS_Domain.USER.Data> output = new List<TRS_Domain.USER.Data>();
            try
            {
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }
                //  the incomplete query
                string query = "SELECT * FROM users WHERE NOT UserID = @id ORDER BY UserSurname";

                //  DEFINE the paramaters
                MySqlParameter param1 = new MySqlParameter();
                param1.ParameterName = "@id";
                param1.Value = clientId;

                //  build the command
                MySqlCommand command = new MySqlCommand(query, _connection);

                //  add the parameters to the command
                command.Parameters.Add(param1);

                //  use the command
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int userId = Convert.ToInt32(reader["UserID"]);
                        string name = Convert.ToString(reader["UserName"]);
                        string surname = Convert.ToString(reader["UserSurname"]);
                        string email = Convert.ToString(reader["UserEmail"]);
                        string region = Convert.ToString(reader["UserRegion"]);
                        string department = Convert.ToString(reader["UserDepartment"]);
                        string phonenumber = Convert.ToString(reader["UserPhoneNumber"]);
                        string quote = Convert.ToString(reader["UserQuote"]);
                        string portfolio = Convert.ToString(reader["UserPortfolio"]);
                        string photolink = Convert.ToString(reader["UserPhotoLink"]);
                        string adres = Convert.ToString(reader["UserAdres"]);
                        int gender = Convert.ToInt32(reader["UserGender"]);
                        int type = Convert.ToInt32(reader["UserType"]);
                        DateTime dob = Convert.ToDateTime(reader["UserDOB"]);
                        byte[] img = null;
                        if (reader["UserProfilePicture"] != DBNull.Value)
                        {
                            img = (byte[])(reader["UserProfilePicture"]);
                        }
                        output.Add(new TRS_Domain.USER.Data(userId, name, surname, email, region, department, phonenumber, quote, portfolio, photolink, adres, gender, type, dob, img));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _connection.Close();
            return output;
        }

        static public void UpdateUserInformation(string username, string usersurname, string useremail, string userregion, string userdepartment, string userPhoneNumber, string userQuote, string userPortfolio, string userAdres, int userId, int gender)
        {
            try
            {
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }
                //incomplete query 
                string query = "UPDATE users SET UserName= @username,UserSurname = @userSurname, UserEmail = @userEmail, UserRegion = @userRegion, UserDepartment = @userDepartment, UserPhoneNumber = @userPhoneNumber, UserQuote = @userQuote, UserPortfolio = @userPortfolio, UserAdres = @userAdres,UserGender = @userGender WHERE  UserID = @UserId";
                //defining parameters
                MySqlParameter param1 = new MySqlParameter();
                param1.ParameterName = "@username";
                param1.Value = username;
                MySqlParameter param2 = new MySqlParameter();
                param2.ParameterName = "@userSurname";
                param2.Value = usersurname;
                MySqlParameter param3 = new MySqlParameter();
                param3.ParameterName = "@userEmail";
                param3.Value = useremail;
                MySqlParameter param4 = new MySqlParameter();
                param4.ParameterName = "@userRegion";
                param4.Value = userregion;
                MySqlParameter param5 = new MySqlParameter();
                param5.ParameterName = "@userDepartment";
                param5.Value = userdepartment;
                MySqlParameter param6 = new MySqlParameter();
                param6.ParameterName = "@userPhoneNumber";
                param6.Value = userPhoneNumber;
                MySqlParameter param7 = new MySqlParameter();
                param7.ParameterName = "@userQuote";
                param7.Value = userQuote;
                MySqlParameter param8 = new MySqlParameter();
                param8.ParameterName = "@userPortfolio";
                param8.Value = userPortfolio;
                MySqlParameter param10 = new MySqlParameter();
                param10.ParameterName = "@userAdres";
                param10.Value = userAdres;
                MySqlParameter param11 = new MySqlParameter();
                param11.ParameterName = "@UserId";
                param11.Value = userId;
                MySqlParameter param12 = new MySqlParameter();
                param12.ParameterName = "@userGender";
                param12.Value = gender;
                MySqlCommand command = new MySqlCommand(query, _connection);

                command.Parameters.Add(param1);
                command.Parameters.Add(param2);
                command.Parameters.Add(param3);
                command.Parameters.Add(param4);
                command.Parameters.Add(param5);
                command.Parameters.Add(param6);
                command.Parameters.Add(param7);
                command.Parameters.Add(param8);
                command.Parameters.Add(param10);
                command.Parameters.Add(param11);
                command.Parameters.Add(param12);
                ExecuteInsert(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _connection.Close();
        }
        static public void UpdateUserInformation(string username, string usersurname, string useremail, string userregion, string userdepartment, string userPhoneNumber, string userQuote, string userPortfolio, string userAdres, int userId, byte[] userProfilePicture, int gender)
        {
            try
            {
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }
                //incomplete query 
                string query = "UPDATE users SET UserName= @username,UserSurname = @userSurname, UserEmail = @userEmail, UserRegion = @userRegion, UserDepartment = @userDepartment, UserPhoneNumber = @userPhoneNumber, UserQuote = @userQuote, UserPortfolio = @userPortfolio, UserAdres = @userAdres, UserProfilePicture = @UserProfilePicture WHERE  UserID = @UserId";
                //defining parameters
                MySqlParameter param1 = new MySqlParameter();
                param1.ParameterName = "@username";
                param1.Value = username;
                MySqlParameter param2 = new MySqlParameter();
                param2.ParameterName = "@userSurname";
                param2.Value = usersurname;
                MySqlParameter param3 = new MySqlParameter();
                param3.ParameterName = "@userEmail";
                param3.Value = useremail;
                MySqlParameter param4 = new MySqlParameter();
                param4.ParameterName = "@userRegion";
                param4.Value = userregion;
                MySqlParameter param5 = new MySqlParameter();
                param5.ParameterName = "@userDepartment";
                param5.Value = userdepartment;
                MySqlParameter param6 = new MySqlParameter();
                param6.ParameterName = "@userPhoneNumber";
                param6.Value = userPhoneNumber;
                MySqlParameter param7 = new MySqlParameter();
                param7.ParameterName = "@userQuote";
                param7.Value = userQuote;
                MySqlParameter param8 = new MySqlParameter();
                param8.ParameterName = "@userPortfolio";
                param8.Value = userPortfolio;
                MySqlParameter param10 = new MySqlParameter();
                param10.ParameterName = "@userAdres";
                param10.Value = userAdres;
                MySqlParameter param11 = new MySqlParameter();
                param11.ParameterName = "@UserId";
                param11.Value = userId;
                MySqlParameter param12 = new MySqlParameter();
                param12.ParameterName = "@UserProfilePicture";
                param12.Value = userProfilePicture;
                MySqlParameter param13= new MySqlParameter();
                param13.ParameterName = "@userGender";
                param13.Value = gender;
                
                MySqlCommand command = new MySqlCommand(query, _connection);

                command.Parameters.Add(param1);
                command.Parameters.Add(param2);
                command.Parameters.Add(param3);
                command.Parameters.Add(param4);
                command.Parameters.Add(param5);
                command.Parameters.Add(param6);
                command.Parameters.Add(param7);
                command.Parameters.Add(param8);
                command.Parameters.Add(param10);
                command.Parameters.Add(param11);
                command.Parameters.Add(param12);
                command.Parameters.Add(param13);
                ExecuteInsert(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _connection.Close();
        }

        public static void CreateUser(string username, string usersurname, string region, string department, string email, string phonenumber, int gender, DateTime dateOb, string oldpassword, int usertype)
        {
            try
            {
                int password = oldpassword.GetHashCode();
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }

                //incomplete query 
                string query = "INSERT INTO users(Online, UserType,UserPassword, UserName, UserSurname, UserEmail, UserRegion, UserDepartment, UserPhoneNumber, UserGender, UserDOB) VALUES (0,@usertype,@password,@username,@usersurname,@useremail,@userregion,@userdepartment,@userphonenumber,@usergender,@userdob)";

                //defining parameters
                MySqlParameter param1 = new MySqlParameter();
                param1.ParameterName = "@usertype";
                param1.Value = usertype;
                MySqlParameter param2 = new MySqlParameter();
                param2.ParameterName = "@password";
                param2.Value = password;
                MySqlParameter param3 = new MySqlParameter();
                param3.ParameterName = "@username";
                param3.Value = username;
                MySqlParameter param4 = new MySqlParameter();
                param4.ParameterName = "@usersurname";
                param4.Value = usersurname;
                MySqlParameter param5 = new MySqlParameter();
                param5.ParameterName = "@useremail";
                param5.Value = email;
                MySqlParameter param6 = new MySqlParameter();
                param6.ParameterName = "@userregion";
                param6.Value = region;
                MySqlParameter param7 = new MySqlParameter();
                param7.ParameterName = "@userdepartment";
                param7.Value = department;
                MySqlParameter param8 = new MySqlParameter();
                param8.ParameterName = "@userphonenumber";
                param8.Value = phonenumber;
                MySqlParameter param9 = new MySqlParameter();
                param9.ParameterName = "@usergender";
                param9.Value = gender;
                MySqlParameter param10 = new MySqlParameter();
                param10.ParameterName = "@userdob";
                param10.Value = dateOb;

                MySqlCommand command = new MySqlCommand(query, _connection);
                command.Parameters.Add(param1);
                command.Parameters.Add(param2);
                command.Parameters.Add(param3);
                command.Parameters.Add(param4);
                command.Parameters.Add(param5);
                command.Parameters.Add(param6);
                command.Parameters.Add(param7);
                command.Parameters.Add(param8);
                command.Parameters.Add(param9);
                command.Parameters.Add(param10);

                ExecuteInsert(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _connection.Close();
        }

        static public void ShutDown() => CloseConn();
    }
}

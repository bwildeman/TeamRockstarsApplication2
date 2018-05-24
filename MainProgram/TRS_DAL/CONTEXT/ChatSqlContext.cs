using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using TRS_DAL.INTERFACES;
using TRS_Domain.CHANNEL.CHAT;

namespace TRS_DAL.CONTEXT
{
    public class ChatSqlContext : IChatContext
    {
        ConnectionDB _connectDb = new ConnectionDB();
        public string MainQuery;
        public dynamic Procedure;
        public MySqlCommand MainCommand;

        public void AddChat(int groupId, string name, string description)
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
                    MainCommand = new MySqlCommand(MainQuery, conn);

                    //  add the parameters to the command
                    MainCommand.Parameters.Add(param1);
                    MainCommand.Parameters.Add(param2);
                    MainCommand.Parameters.Add(param3);

                    //  use the command
                    _connectDb.ExecuteNonQuery(MainCommand);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddMessage(int user, int chat, string message, DateTime time)
        {
            //Try-Catch for safety:
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();

                    //  the incomplete query
                    MainQuery = "INSERT INTO `chatmessages`(`ChatID`, `UserID`, `Message`, `SendDate`) VALUES(@chatID, @userID, @message, @sendDate)";

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
                    MainCommand = new MySqlCommand(MainQuery, conn);

                    //  add the parameters to the command
                    MainCommand.Parameters.Add(param1);
                    MainCommand.Parameters.Add(param2);
                    MainCommand.Parameters.Add(param3);
                    MainCommand.Parameters.Add(param4);

                    //  use the command
                    MainCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Chat> GetAllChats(int groupId)
        {
            //  Define output:
            List<Chat> output = new List<Chat>();

            //Try-Catch for safety:
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();

                    //  the incomplete query
                    MainQuery = "SELECT * FROM `chats` WHERE GroupID = @id";

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
                                //Retrieve information from the database and put it into a class.
                                int chatId = Convert.ToInt32(reader["ChatID"]);
                                string chatName = Convert.ToString(reader["ChatName"]);
                                string chatDescription = Convert.ToString(reader["ChatDescription"]);
                                output.Add(new Chat(chatId, chatName, chatDescription));
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

        public List<Message> GetMessages(int chatId)
        {
            //Define output:
            List<Message> output = new List<Message>();
            //Try-Catch for safety:
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();

                    //  the incomplete query
                    MainQuery = "SELECT `MessageID`, `ChatID`, `Message`, `SendDate`, users.UserName, users.UserSurname FROM `chatmessages` INNER JOIN users ON  users.UserID = chatmessages.UserID WHERE ChatID = @id ORDER BY SendDate";

                    //  DEFINE the paramaters
                    MySqlParameter param1 = new MySqlParameter();
                    param1.ParameterName = "@id";
                    param1.Value = chatId;

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, conn);

                    //  add the parameters to the command
                    MainCommand.Parameters.Add(param1);

                    //  use the command
                    using (MySqlDataReader reader = MainCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = Convert.ToString(reader["UserName"]);
                            string surname = Convert.ToString(reader["UserSurname"]);
                            string message = Convert.ToString(reader["Message"]);
                            string sendDate = Convert.ToDateTime(reader["SendDate"]).ToShortDateString();
                            output.Add(new Message($"{name} {surname}", message, sendDate));
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

        public bool MessageAdded(string message, DateTime time)
        {
            //Define output
            bool output = false;

            //Try-Catch for safety:
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();

                    //  the incomplete query
                    MainQuery = "SELECT COUNT(UserID) FROM user WHERE ChatMessage = @message AND SendDate = @date";

                    //  DEFINE the paramaters
                    MySqlParameter param5 = new MySqlParameter();
                    param5.ParameterName = "@message";
                    param5.Value = message;

                    MySqlParameter param6 = new MySqlParameter();
                    param5.ParameterName = "@date";
                    param5.Value = time;

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, conn);

                    //  add the parameters to the command
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
    }
}

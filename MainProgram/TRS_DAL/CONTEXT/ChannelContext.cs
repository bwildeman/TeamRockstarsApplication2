using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using TRS_DAL.INTERFACES;
using TRS_Domain.CHANNEL;
using TRS_Domain.CHANNEL.CHAT;
using TRS_Domain.EVENT;

namespace TRS_DAL.CONTEXT
{
    public class ChannelContext : IChannelContext
    {
        ConnectionDB _connectDb = new ConnectionDB();
        public string MainQuery;
        public dynamic Procedure;
        public MySqlCommand MainCommand;

        public void AddChannel(string Name, string Description, int type, int groupId)
        {


            //Try-Catch for safety:
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();

                    //  the incomplete query
                    switch (type)
                    {
                        case 1: //voeg chat toe
                            MainQuery =
                                "INSERT INTO `chats` (`GroupID`,`ChatName`, `ChatDescription`) " +
                                "VALUES(@GroupID, @Name, @Description)";

                            break;
                        case 3: //voeg forum toe
                            MainQuery =
                                "INSERT INTO `forum` (`GroupID`,`ForumName`, `Description`) " +
                                "VALUES(@GroupID, @Name, @Description)";

                            break;
                    }
                    //  DEFINE the paramaters
                    MySqlParameter param1 = new MySqlParameter();
                    param1.ParameterName = "@GroupID";
                    param1.Value = groupId;

                    MySqlParameter param2 = new MySqlParameter();
                    param2.ParameterName = "@Name";
                    param2.Value = Name;

                    MySqlParameter param3 = new MySqlParameter();
                    param3.ParameterName = "@Description";
                    param3.Value = Description;

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




            //een event forum of chat toevoegen en de trigger voegt de channel toe ik moet meerdere van deze functies hebben omdat sommige verschillende params hebben
        }
       
        public void AddEvent(string Name, string Description, int type,DateTime starttime, DateTime endtime,bool online, string locationurl, int userID, int groupID)
        {
            //voeg event toe
            using (MySqlConnection conn = _connectDb.GetConnection())
            {
                try
                {

                    conn.Open();

                    //  the incomplete query
                    MainQuery =
                        "INSERT INTO `event`(`UserID`, `GroupID`, `Name`, `StartDate`, `EndDate`, `Online`, `Location_Url`, `Description`)" +
                        "VALUES (@userID,@GroupID,@Name,@StartDate,@EndDate,@Online,@LocationUrl,@Description)";


                    //  DEFINE the paramaters
                    MySqlParameter param1 = new MySqlParameter();
                    param1.ParameterName = "@UserID";
                    param1.Value = userID;

                    MySqlParameter param2 = new MySqlParameter();
                    param2.ParameterName = "@GroupID";
                    param2.Value = groupID;

                    MySqlParameter param3 = new MySqlParameter();
                    param3.ParameterName = "@Name";
                    param3.Value = Name;
                    MySqlParameter param4 = new MySqlParameter();
                    param4.ParameterName = "@StartDate";
                    param4.Value = starttime;
                    MySqlParameter param5 = new MySqlParameter();
                    param5.ParameterName = "@EndDate";
                    param5.Value = endtime;
                    MySqlParameter param6 = new MySqlParameter();
                    param6.ParameterName = "@Online";
                    param6.Value = online;
                    MySqlParameter param7 = new MySqlParameter();
                    param7.ParameterName = "@LocationUrl";
                    param7.Value = locationurl;
                    MySqlParameter param8 = new MySqlParameter();
                    param8.ParameterName = "@Description";
                    param8.Value = online;

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, conn);

                    //  add the parameters to the command
                    MainCommand.Parameters.Add(param1);
                    MainCommand.Parameters.Add(param2);
                    MainCommand.Parameters.Add(param3);
                    MainCommand.Parameters.Add(param4);
                    MainCommand.Parameters.Add(param5);
                    MainCommand.Parameters.Add(param6);
                    MainCommand.Parameters.Add(param7);
                    MainCommand.Parameters.Add(param8);
                    _connectDb.ExecuteNonQuery(MainCommand);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }


        public void DeleteChannel(int groupId, int Id,int type)
        {
            try
            {
                using (MySqlConnection Conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    Conn.Open();

                    switch (type)
                    {
                        case 1: //delete chat
                            MainQuery =
                                "DELETE FROM `chats` WHERE `ChatID`= @Id AND`GroupID` = @groupId";
                            break;

                        case 2: //delete event
                            MainQuery =
                                "DELETE FROM `forum` WHERE `EventID`= @Id AND`GroupID` = @groupId";
                            break;
                        case 3: //delete forum
                            MainQuery =
                                "DELETE FROM `forum` WHERE `ForumID`= @Id AND`GroupID` = @groupId";
                    
                            break;
                    }
                    //  DEFINE the paramaters
                    MySqlParameter param1 = new MySqlParameter();
                    param1.ParameterName = "@groupId";
                    param1.Value = groupId;

                    MySqlParameter param2 = new MySqlParameter();
                    param2.ParameterName = "@Id";
                    param2.Value = Id;

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, Conn);

                    //  add the parameters to the command
                    MainCommand.Parameters.Add(param1);
                    MainCommand.Parameters.Add(param2);
                    //  use the command
                    _connectDb.ExecuteNonQuery(MainCommand);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }




            //gebaseerd op het type een switch maken waarin de delete wordt gedaan
        }

        public Channel GetChannel(int groupId, int Id, int type)
        {

            //bij de parameters moet het type erbij
            //dit haalt de data op van de channel inner join alle data meepakken
            throw new System.NotImplementedException();
        }

        public Channel[] GetChannels(int groupId)
        {

            //haalt alle data van alle channels van een groep op
            throw new System.NotImplementedException();
        }

        public void UpdateDescription(int groupID, int channelID,int type,string newName)
        {
            switch (type)
            {
                case 1: //delete chat
                    break;

                case 2: //delete event
                    break;
                case 3: //delete forum
                    break;
            }
            //past de description van een channel aan gebaseerd op type welke tabel
            throw new System.NotImplementedException();
        }

        public void UpdateName(int groupID, int channelID,int type,string newName)
        {
            switch (type)
            {
                case 1: //delete chat
                    break;

                case 2: //delete event
                    break;
                case 3: //delete forum
                    break;
            }
            //past de naam van een channel aan gebaseerd op type welke tabel
            throw new System.NotImplementedException();
        }
    }
}

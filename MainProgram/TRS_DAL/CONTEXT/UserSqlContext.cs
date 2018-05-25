using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using TRS_DAL.INTERFACES;
using TRS_Domain;

namespace TRS_DAL.CONTEXT
{
    public class UserSqlContext : IUserContext
    {
        ConnectionDB _connectDb = new ConnectionDB();
        public string MainQuery;
        public dynamic Procedure;
        public MySqlCommand MainCommand;

        public void CreateUser(string username, string usersurname, string region, string department, string email, string phonenumber, int gender, DateTime dateOb, string oldpassword, int usertype)
        {
            //  Try-Catch for safety:
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    // Open Connection:
                    conn.Open();

                    //  TODO write this into the logic layer:
                    int password = oldpassword.GetHashCode();

                    //incomplete query 
                    MainQuery = @"INSERT INTO users(Online, UserType,UserPassword, UserName, UserSurname, UserEmail, UserRegion, UserDepartment, UserPhoneNumber, UserGender, UserDOB) 
                                    VALUES (0,@usertype,@password,@username,@usersurname,@useremail,@userregion,@userdepartment,@userphonenumber,@usergender,@userdob)";

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
                    MainCommand.Parameters.Add(param9);
                    MainCommand.Parameters.Add(param10);

                    //  use the command
                    _connectDb.ExecuteNonQuery(MainCommand);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<TRS_Domain.USER.Data> GetAllUsers()
        {
            //Define output:
            List<TRS_Domain.USER.Data> output = new List<TRS_Domain.USER.Data>();

            //  Try-Catch for Safety:
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();

                    //  the incomplete query
                    MainQuery = "SELECT * FROM users ORDER BY UserSurname";

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, conn);

                    //  use the command
                    using (MySqlDataReader reader = MainCommand.ExecuteReader())
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return output;
        }

        public List<TRS_Domain.USER.Data> GetAllUsers(int clientId)
        {
            //Define output:
            List<TRS_Domain.USER.Data> output = new List<TRS_Domain.USER.Data>();

            //  Try-Catch for Safety:
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open connection:
                    conn.Open();

                    //  the incomplete query
                    MainQuery = "SELECT * FROM users WHERE NOT UserID = @id ORDER BY UserSurname";

                    //  DEFINE the paramaters
                    MySqlParameter param1 = new MySqlParameter();
                    param1.ParameterName = "@id";
                    param1.Value = clientId;

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, conn);

                    //  add the parameters to the command
                    MainCommand.Parameters.Add(param1);

                    //  use the command
                    using (MySqlDataReader reader = MainCommand.ExecuteReader())
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return output;
        }

        public List<TRS_Domain.USER.Data> GetAllUsersName()
        {
            //Define output:
            List<TRS_Domain.USER.Data> output = new List<TRS_Domain.USER.Data>();

            //  Try-Catch for Safety:
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection
                    conn.Open();

                    //  the incomplete query
                    MainQuery = "SELECT UserID, UserName, UserSurname FROM users ORDER BY UserSurname";


                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, conn);

                    //  use the command
                    using (MySqlDataReader reader = MainCommand.ExecuteReader())
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return output;
        }

        public TRS_Domain.USER.Data GetUser(int id)
        {
            //Define output:
            TRS_Domain.USER.Data output = new TRS_Domain.USER.Data();

            //use try so the code doesn`t crash
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    // Open Connection:
                    conn.Open();

                    //  the incomplete query
                    MainQuery = "Select * FROM users WHERE UserID = @id";

                    //  DEFINE the paramaters
                    MySqlParameter param1 = new MySqlParameter();
                    param1.ParameterName = "@id";
                    param1.Value = id;

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
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return output;
        }

        public int Login(string email, string oldpassword)
        {
            //Define output:
            int output = 0;

            // Try-Catch for Safety:
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    // Open Conn:
                    conn.Open();

                    //  TODO Write this to Logic Layer:
                    //Change input:
                    int password = oldpassword.GetHashCode();

                    //  the incomplete query
                    MainQuery = "Select UserID FROM users WHERE UserEmail = @email AND UserPassword = @password";

                    //  DEFINE the paramaters
                    MySqlParameter param1 = new MySqlParameter();
                    param1.ParameterName = "@email";
                    param1.Value = email;

                    MySqlParameter param2 = new MySqlParameter();
                    param2.ParameterName = "@password";
                    param2.Value = password;

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, conn);

                    //  add the parameters to the command
                    MainCommand.Parameters.Add(param1);
                    MainCommand.Parameters.Add(param2);

                    //  use the command
                    using (MySqlDataReader reader = MainCommand.ExecuteReader())
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
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return output;
        }

        public void UpdateUserInformation(string username, string usersurname, string useremail, string userregion, string userdepartment, string userPhoneNumber, string userQuote, string userPortfolio, string userAdres, int userId, int gender)
        {
            //  Try-Catch for Safety:
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();

                    //incomplete query 
                    MainQuery = "UPDATE users SET UserName= @username,UserSurname = @userSurname, UserEmail = @userEmail, UserRegion = @userRegion, UserDepartment = @userDepartment, UserPhoneNumber = @userPhoneNumber, UserQuote = @userQuote, UserPortfolio = @userPortfolio, UserAdres = @userAdres,UserGender = @userGender WHERE  UserID = @UserId";

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
                    MainCommand.Parameters.Add(param10);
                    MainCommand.Parameters.Add(param11);
                    MainCommand.Parameters.Add(param12);

                    //  use the command
                    _connectDb.ExecuteNonQuery(MainCommand);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateUserInformation(string username, string usersurname, string useremail, string userregion, string userdepartment, string userPhoneNumber, string userQuote, string userPortfolio, string userAdres, int userId, byte[] userProfilePicture, int gender)
        {
            //  Try-Catch for Safety:
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();

                    //incomplete query 
                    MainQuery = "UPDATE users SET UserName= @username,UserSurname = @userSurname, UserEmail = @userEmail, UserRegion = @userRegion, UserDepartment = @userDepartment, UserPhoneNumber = @userPhoneNumber, UserQuote = @userQuote, UserPortfolio = @userPortfolio, UserAdres = @userAdres, UserProfilePicture = @UserProfilePicture WHERE  UserID = @UserId";

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
                    MySqlParameter param13 = new MySqlParameter();
                    param13.ParameterName = "@userGender";
                    param13.Value = gender;

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
                    MainCommand.Parameters.Add(param10);
                    MainCommand.Parameters.Add(param11);
                    MainCommand.Parameters.Add(param12);
                    MainCommand.Parameters.Add(param13);

                    //  Use the command:
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

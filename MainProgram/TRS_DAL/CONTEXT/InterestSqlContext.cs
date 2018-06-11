using System;
using System.Collections.Generic;
using System.Text;
using TRS_DAL.INTERFACES;
using TRS_Domain;
using TRS_Domain.CATEGORY;
using TRS_Domain.INTEREST;
using MySql.Data.MySqlClient;
using Data = TRS_Domain.INTEREST.Data;

namespace TRS_DAL.CONTEXT
{
    public class InterestSqlContext : IInterestContext
    {
        ConnectionDB _connectDb = new ConnectionDB();
        public string MainQuery;
        public dynamic Procedure;
        public MySqlCommand MainCommand;

        public void AddNewInterest(string interestName, int interestId)
        {
            //  Try-Catch for Safety:
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();

                    //incomplete query 
                    MainQuery = "INSERT INTO interest (InterestName, InterestPending, InterestCategory) " +
                        "VALUES (@interestName, 0, @interestId)";

                    //defining parameters
                    MySqlParameter param1 = new MySqlParameter();
                    param1.ParameterName = "@interestName";
                    param1.Value = interestName;
                    MySqlParameter param2 = new MySqlParameter();
                    param2.ParameterName = "@interestId";
                    param2.Value = interestId;

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, conn);

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

        public void VerifyInterest(int interestId)
        {
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();

                    //incomplete query 
                    MainQuery = "UPDATE interest " +
                                "SET InterestPending = 0 " +
                                "WHERE InterestID = @interestId";

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, conn);
                    MainCommand.Parameters.AddWithValue("@interestId", interestId);

                    //  use the command
                    _connectDb.ExecuteNonQuery(MainCommand);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UnVerifyInterest(int interestId)
        {
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();

                    //incomplete query 
                    MainQuery = "UPDATE interest " +
                                "SET InterestPending = 1 " +
                                "WHERE InterestID = @interestId";

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, conn);
                    MainCommand.Parameters.AddWithValue("@interestId", interestId);

                    //  use the command
                    _connectDb.ExecuteNonQuery(MainCommand);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        // TODO: ADD SPECIFIC USER QUERRY
        public List<Data> GetUserCategoryInterests(int categoryId, int userId)
        {
            List<TRS_Domain.INTEREST.Data> output = new List<Data>();
            //  Try-Catch for Safety:
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();


                    //  the incomplete query
                    MainQuery = "SELECT interest.InterestID, interest.InterestName, interest.InterestCategory " +
                                "FROM interest " +
                                "WHERE interest.InterestCategory = @categoryId " +
                                "AND interest.InterestPending = 0";

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, conn);
                    MainCommand.Parameters.AddWithValue("@userId", userId);
                    MainCommand.Parameters.AddWithValue("@categoryId", categoryId);
                    //  use the command
                    using (MySqlDataReader reader = MainCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = Convert.ToInt32(reader["InterestID"]);
                            var name = Convert.ToString(reader["InterestName"]);
                            var categoryID = Convert.ToInt32(reader["InterestCategory"]);
                            output.Add(new TRS_Domain.INTEREST.Data(name, id, categoryID));
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

        public void ClearUserInterests(int userId)
        {
            //  Try-Catch for Safety:
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();

                    //incomplete query 
                    MainQuery = "DELETE FROM interest_user " +
                                "WHERE UserID = @userId";

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, conn);

                    //  add the parameters to the command
                    MainCommand.Parameters.AddWithValue("@userId", userId);

                    //  use the command
                    _connectDb.ExecuteNonQuery(MainCommand);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddUserInterest(int userId, int interestId)
        {
            //  Try-Catch for Safety:
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();

                    //incomplete query 
                    MainQuery = "INSERT INTO interest_user (InterestID, UserID) " +
                        "VALUES (@interestId, @userId)";

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, conn);

                    //  add the parameters to the command
                    MainCommand.Parameters.AddWithValue("@interestId", interestId);
                    MainCommand.Parameters.AddWithValue("@userId", userId);

                    //  use the command
                    _connectDb.ExecuteNonQuery(MainCommand);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<TRS_Domain.CATEGORY.Data> GetAllCategory()
        {
            //Define output:
            List<TRS_Domain.CATEGORY.Data> output = new List<TRS_Domain.CATEGORY.Data>();

            //  Try-Catch for Safety:
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();

                    //  the incomplete query
                    MainQuery = "SELECT * FROM Interest_category";

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, conn);
                    //  use the command
                    using (MySqlDataReader reader = MainCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var name = Convert.ToString(reader["categoryName"]);
                            var id = Convert.ToInt32(reader["categoryID"]);
                            output.Add(new TRS_Domain.CATEGORY.Data(name, id));
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

        public List<TRS_Domain.INTEREST.Data> GetAllVerifiedInterests()
        {
            List<TRS_Domain.INTEREST.Data> output = new List<Data>();
            //  Try-Catch for Safety:
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();

                    //  the incomplete query
                    MainQuery = "SELECT * FROM interest " +
                                "WHERE interest.InterestPending = 0";

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, conn);
                    //  use the command
                    using (MySqlDataReader reader = MainCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = Convert.ToInt32(reader["InterestID"]);
                            var name = Convert.ToString(reader["InterestName"]);
                            var categoryId = Convert.ToInt32(reader["InterestCategory"]);
                            output.Add(new TRS_Domain.INTEREST.Data(name, id, categoryId));
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

        public List<TRS_Domain.INTEREST.Data> GetAllNotVerifiedInterests()
        {
            List<TRS_Domain.INTEREST.Data> output = new List<Data>();
            //  Try-Catch for Safety:
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();

                    //  the incomplete query
                    MainQuery = "SELECT * FROM interest " +
                                "WHERE interest.InterestPending = 1";

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, conn);
                    //  use the command
                    using (MySqlDataReader reader = MainCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = Convert.ToInt32(reader["InterestID"]);
                            var name = Convert.ToString(reader["InterestName"]);
                            var categoryId = Convert.ToInt32(reader["InterestCategory"]);
                            output.Add(new TRS_Domain.INTEREST.Data(name, id, categoryId));
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

        public List<TRS_Domain.INTEREST.Data> GetUserInterests(int userId)
        {
            List<TRS_Domain.INTEREST.Data> output = new List<Data>();
            //  Try-Catch for Safety:
            try
            {
                using (MySqlConnection conn = _connectDb.GetConnection())
                {
                    //  Open Connection:
                    conn.Open();

                    //  the incomplete query
                    MainQuery = "SELECT interest.InterestName, interest.InterestID, interest.InterestCategory " +
                                "FROM interest " +
                                "INNER JOIN interest_user " +
                                "ON interest.InterestID = interest_user.InterestID " +
                                "WHERE interest_User.UserID = @userID " +
                                "AND interest.InterestPending = 0";

                    //  build the command
                    MainCommand = new MySqlCommand(MainQuery, conn);
                    MainCommand.Parameters.AddWithValue("@userID", userId);

                    //  use the command
                    using (MySqlDataReader reader = MainCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = Convert.ToInt32(reader["InterestID"]);
                            var name = Convert.ToString(reader["InterestName"]);
                            var categoryId = Convert.ToInt32(reader["InterestCategory"]);
                            output.Add(new TRS_Domain.INTEREST.Data(name, id, categoryId));
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
    }
}

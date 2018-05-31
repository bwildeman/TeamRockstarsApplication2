using System;
using System.Collections.Generic;
using System.IO;
using TRS_DAL.REPOSITORIES;

namespace TRS_Logic
{
    public class UserLogic
    {
        // DAL reference:
        UserRepository _userRepo = new UserRepository();
        GroupRepository _groupRepo = new GroupRepository();
        
        //  Private memory:
        private byte[] _profilepicture;

        //  Private methodes:
        private void Savepicture(string profilepicture)
        {
            _profilepicture = File.ReadAllBytes($@"{profilepicture}");
        }

        //  Other methodes:
        public List<TRS_Domain.USER.Data> AllUsers()
        {
            return _userRepo.GetAllUsersName();
        }

        public TRS_Domain.USER.Data UpdateUserInformation(TRS_Domain.USER.Data selectedUser)
        {
            return _userRepo.GetUser(selectedUser.UserId);
        }

        public bool SaveUser(int userId, string name, string surName, string region, string residence, string email, string phoneNumber, string profilePic, string gender, string function, string qoute, string portfolio)
        {
            //  Define output:
            bool output = false;

            //  Try-Catch for safety:
            try
            {
                //define output 
                int genderint = 0;
                //  Ex handling doen TODO:

                //  Change input:

                //  Database

                switch (gender)
                {
                    case "Female":
                        genderint = 0;
                        break;
                    case "Male":
                        genderint = 1;
                        break;
                    case "Unassigned":
                        genderint = 2;
                        break;
                }
                if (!string.IsNullOrEmpty(profilePic))
                {
                    Savepicture(profilePic);

                    _userRepo.UpdateUserInformation(name, surName, email, region, function, phoneNumber, qoute, portfolio, residence, userId, _profilepicture, genderint);
                    output = true;
                }
                else
                {
                    _userRepo.UpdateUserInformation(name, surName, email, region, function, phoneNumber, qoute, portfolio, residence, userId, genderint);
                    output = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return output;
        }

        public bool AddUser(string name, string surName, string email, string region, string phonenumber, string adres, string gender, bool? noRights, bool? yesRights, DateTime dob)
        {
            //  Define output:
            bool output = false;

            try
            {
                // Change input:
                bool NoRights = noRights ?? false;
                bool YesRights = yesRights ?? false;
                // Validate input:
                if (exHanlder.NewUser(name, surName, email, region, phonenumber, adres, gender, NoRights, YesRights, dob))
                {
                    //  Change input:
                    int Gender = 2;
                    int UserType = 0;
                    string Password = $"{name}".GetHashCode().ToString();
                    if (gender == "Male")
                    {
                        Gender = 1;
                    }
                    else if(gender == "Female")
                    {
                        Gender = 0;
                    }
                    if (YesRights)
                    {
                        UserType = 1;
                    }

                    // Database:
                    output = _userRepo.CreateUser(name, surName, email, region, phonenumber, adres, Gender, UserType, dob, Password);

                }

            }
            catch (EmptyField ex)
            {
                throw ex;
            }
            catch (InvalidEmail ex)
            {
                throw ex;
            }
            catch (StringContainsDigit ex)
            {
                throw ex;
            }
            catch (StringContainsLeter ex)
            {
                throw ex;
            }
            catch(InvalidAdminRightsSelection ex)
            {
                throw ex;
            }
            catch(InvalidDOB ex)
            {
                throw ex;
            }

            return output;
        }

        public TRS_Domain.USER.Data GetUser(int userId)
        {
            return _userRepo.GetUser(userId);
        }

    }
}

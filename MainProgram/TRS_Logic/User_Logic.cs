using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Controls;
using TRS_DAL;
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

        public TRS_Domain.USER.Data GetUser(int userId)
        {
            return _userRepo.GetUser(userId);
        }

    }
}

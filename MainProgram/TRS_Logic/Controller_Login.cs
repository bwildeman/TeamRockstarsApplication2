using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using TRS_DAL;
using TRS_DAL.REPOSITORIES;
using TRS_Domain;

namespace TRS_Logic
{
    public class ControllerLogin
    {
        //  Add DAL referenceL
        UserRepository _userRepo = new UserRepository();


        /// <summary>
        /// Check username and password with database
        /// </summary>
        /// <param name="bT_Login"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public int Login(string email, string password)
        {
            //  Define output:
            int output = -1;
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                _userRepo.Login(email, password);
                int userId = _userRepo.Login(email, password); ;
                if (userId == 0)
                {
                }
                else if (userId == -1)
                {
                }
                else
                {
                    output = userId;
                }
            }
            return output;
        }

        public bool InputFilled(string email, string password)
        {
            bool output = false;
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                output = true;
            }
            return output;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using TRS_DAL;
using TRS_DAL.REPOSITORIES;
using TRS_Domain;
using TRS_Domain.EXCEPTIONS;

namespace TRS_Logic
{
    public class ControllerLogin
    {
        //  Add references
        UserRepository _userRepo = new UserRepository();
        ExceptionHandler exHanlder = new ExceptionHandler();


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

            try
            {

                //  Check input:
                if (exHanlder.Login(email, password))
                {
                    _userRepo.Login(email, password);
                    int userId = _userRepo.Login(email, password); ;
                    if (userId == 0) { throw new InvalidLoginCombination(); }
                    else
                    {
                        output = userId;
                    }
                }
            }
            catch(EmptyField ex)
            {
                throw ex;
            }
            catch(InvalidEmail ex)
            {
                throw ex;
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

        public bool ValidEmail(string email)
        {
            try
            {
                exHanlder.ValidEmail(email);
                return true;
            }
            catch (InvalidEmail ex)
            {
                throw ex;
            }
        }
    }
}

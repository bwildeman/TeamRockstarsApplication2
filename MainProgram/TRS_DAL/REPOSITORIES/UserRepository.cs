using System;
using System.Collections.Generic;
using System.Text;
using TRS_DAL.CONTEXT;
using TRS_DAL.INTERFACES;
using TRS_Domain.USER;

namespace TRS_DAL.REPOSITORIES
{
    public class UserRepository
    {
        //  Context reference:
        IUserContext _userContext = new UserSqlContext();


        //  List methodes:
        public List<TRS_Domain.USER.Data> GetAllUsers()
        {
            return _userContext.GetAllUsers();
        }
        public List<TRS_Domain.USER.Data> GetAllUsers(int clientId)
        {
            return _userContext.GetAllUsers(clientId);
        }
        public List<TRS_Domain.USER.Data> GetAllUsersName()
        {
            return _userContext.GetAllUsersName();
        }


        public bool CreateUser(string name, string surName, string email, string region, string phonenumber, string adres, int gender, int userType, DateTime dob, string password)
        {
            return _userContext.CreateUser(name, surName, email, region, phonenumber, adres, gender, userType, dob, password);
        }

        public TRS_Domain.USER.Data GetUser(int id)
        {
            return _userContext.GetUser(id);
        }

        public int Login(string email, string oldpassword)
        {
            return _userContext.Login(email, oldpassword);
        }

        public void UpdateUserInformation(string username, string usersurname, string useremail, string userregion, string userdepartment, string userPhoneNumber, string userQuote, string userPortfolio, string userAdres, int userId, int gender)
        {
            _userContext.UpdateUserInformation(username, usersurname, useremail, userregion, userdepartment, userPhoneNumber, userQuote, userPortfolio, userAdres, userId, gender);
        }

        public void UpdateUserInformation(string username, string usersurname, string useremail, string userregion, string userdepartment, string userPhoneNumber, string userQuote, string userPortfolio, string userAdres, int userId, byte[] userProfilePicture, int gender)
        {
            _userContext.UpdateUserInformation(username, usersurname, useremail, userregion, userdepartment, userPhoneNumber, userQuote, userPortfolio, userAdres, userId, userProfilePicture, gender);
        }

        public bool UpdatePassword(string password, Data user)
        {
            return _userContext.UpdatePassword(password, user);
        }
    }
}

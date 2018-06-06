using System;
using System.Collections.Generic;
using System.Text;
using TRS_DAL.CONTEXT;
using TRS_DAL.INTERFACES;

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


        public void CreateUser(string username, string usersurname, string region, string department, string email, string phonenumber, int gender, DateTime dateOb, string oldpassword, int usertype)
        {
            _userContext.CreateUser(username, usersurname, region, department, email, phonenumber, gender, dateOb, oldpassword, usertype);
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
    }
}

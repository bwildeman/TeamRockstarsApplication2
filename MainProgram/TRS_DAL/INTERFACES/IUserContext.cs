using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_DAL.INTERFACES
{
    interface IUserContext
    {
        List<TRS_Domain.USER.Data> GetAllUsers();

        List<TRS_Domain.USER.Data> GetAllUsers(int clientId);

        List<TRS_Domain.USER.Data> GetAllUsersName();

        bool CreateUser(string name, string surName, string email, string region, string phonenumber, string adres, int gender, int userType, DateTime dob, string password);

        TRS_Domain.USER.Data GetUser(int id);

        int Login(string email, string oldpassword);

        void UpdateUserInformation(string username, string usersurname, string useremail, string userregion, string userdepartment, string userPhoneNumber, string userQuote, string userPortfolio, string userAdres, int userId, int gender);

        void UpdateUserInformation(string username, string usersurname, string useremail, string userregion, string userdepartment, string userPhoneNumber, string userQuote, string userPortfolio, string userAdres, int userId, byte[] userProfilePicture, int gender);
        bool UpdatePassword(string password, TRS_Domain.USER.Data user);
    }
}

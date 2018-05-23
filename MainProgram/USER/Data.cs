using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram.USER
{
    public class Data
    {
        // ********** PROPERTIES **********
        public int UserId { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public string Region { get; private set; }
        public string Department { get; private set; }
        public string Phonenumber { get; private set; }
        public string Quote { get; private set; }
        public string Portfolio { get; private set; }
        public string PhotoLink { get; private set; }
        public string Adres { get; private set; }
        public int Gender { get; private set; }
        public int Type { get; private set; }
        public DateTime Dob { get; private set; }
        public byte[] Img { get; private set; }
        public List<GROUP.Data> Groups { get; private set; }

        public Data(int userId, string name, string surname, string email, string region, string department, string phonenumber, string quote, string portfolio, string photolink, string adres, int gender, int type, DateTime dob, byte[] img)
        {
            UserId = userId;
            Name = name;
            Surname = surname;
            Email = email;
            Region = region;
            Department = department;
            Phonenumber = phonenumber;
            Quote = quote;
            Portfolio = portfolio;
            PhotoLink = photolink;
            Adres = adres;
            Gender = gender;
            Type = type;
            Dob = dob;
            Img = img;
        }

        public Data()
        {

        }

        public Data LoadUser(int userId, Data input)
        {
           input = DATABASE.DbConnect.GetUser(userId);
           input.Groups = DATABASE.DbConnect.GetGroups(input.UserId);

            return input;
        }

        public void UpdateUserInformation()
        {
            USER.Data newData = DATABASE.DbConnect.GetUser(this.UserId);
            this.Name = newData.Name;
            this.Surname = newData.Surname;
            this.Department = newData.Department;
            this.Region = newData.Region;
            this.Email = newData.Email;
            this.Phonenumber = newData.Phonenumber;
            this.Quote = newData.Quote;
            this.PhotoLink = newData.PhotoLink;
            this.Img = newData.Img;
            this.Portfolio = newData.Portfolio;
            this.Adres = newData.Adres;
            
        }

        public void ReloadGroups()
        {
            this.Groups = DATABASE.DbConnect.GetGroups(this.UserId);
        }

        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }
}

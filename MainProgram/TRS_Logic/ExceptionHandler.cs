using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TRS_Domain.EXCEPTIONS;

namespace TRS_Logic
{
    public class ExceptionHandler
    {
        //  Private checks:
        private void FieldEmpty(string input, string fieldName)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new EmptyField(fieldName);
            }
        }
        private void ValidateEmail(string email)
        {
            string Pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (!Regex.IsMatch(email, Pattern))
            {
                throw new InvalidEmail();
            }
        }
        private void ContainsDigit(string input, string fieldName)
        {
            if (input.Any(c => char.IsDigit(c)))
            {
                throw new StringContainsDigit(fieldName);
            }
        }
        private void ContainsLeter(string input, string fieldName)
        {
            if (input.Any(c => char.IsLetter(c)))
            {
                throw new StringContainsLeter(fieldName);
            }
        }
        private void ImageSize(string input)
        {
            //  Max photo size:
            int MaxSize = 3670016;
            try
            {
                if (!string.IsNullOrEmpty(input))
                {
                    //  Set byte map
                    byte[] byteMapPhoto  = File.ReadAllBytes($@"{input}");

                    if (byteMapPhoto.Length >= MaxSize)
                    {
                        string size = String.Format("{0:##.##}", byteMapPhoto.Length / 1048576.0) + " MB";
                        throw new MaxPhotoSizeReached(size);
                    }
                }
            }
            catch(MaxPhotoSizeReached ex)
            {
                throw ex;
            }
            catch(System.IO.FileNotFoundException ex)
            {
                throw new PhotoNotFound();
            }
        }
        private void ValidateAdminRights(bool noRights, bool yesRights)
        {
            if (noRights == yesRights)
            {
                throw new InvalidAdminRightsSelection();
            }
        }

        private void ValidateDOB(DateTime dob)
        {
            if (dob > DateTime.Now)
            {
                throw new InvalidDOB();
            }
        }

        //  Public methodes:
        public bool Login(string email, string password)
        {
            //  Check if all fields are filled:
            FieldEmpty(email, "email");
            FieldEmpty(password, "password");

            //  Validate email:
            ValidateEmail(email);

            return true;
        }

        public bool ValidEmail(string email)
        {
            //  Validate email:
            ValidateEmail(email);

            return true;
        }

        public bool SaveProfile(string name, string surName, string region, string residence, string email, string phoneNumber, string profilePic, string gender, string function, string qoute, string portfolio)
        {
            //  Check if all required fields are filled:
            FieldEmpty(name, "name");
            FieldEmpty(surName, "surname");
            FieldEmpty(email, "email");
            FieldEmpty(region, "region");
            FieldEmpty(function, "function");
            FieldEmpty(phoneNumber, "phonenumber");
            FieldEmpty(gender, "gender");

            //  Check for digits:
            ContainsDigit(name, "name");
            ContainsDigit(surName, "surname");
            ContainsDigit(region, "region");

            //  Check if letters:
            ContainsLeter(phoneNumber, "phonenumber");

            //  Check if photo isn't to big:
            ImageSize(profilePic);

            //  Check if email is valid:
            ValidateEmail(email);

            return true;
        }

        public bool NewUser(string name, string surName, string email, string region, string phonenumber, string adres, string gender, bool noRights, bool yesRights, DateTime dob)
        {
            // Check if all required fields are filled:
            FieldEmpty(name, "name");
            FieldEmpty(surName, "surname");
            FieldEmpty(email, "email");
            FieldEmpty(region, "region");
            FieldEmpty(adres, "adres");
            // Missing function, because that is a personal field to be filled in.
            FieldEmpty(phonenumber, "phonenumber");
            FieldEmpty(gender, "gender");

            //  Check for digits:
            ContainsDigit(name, "name");
            ContainsDigit(surName, "surname");
            ContainsDigit(region, "region");

            //  Check if letters:
            ContainsLeter(phonenumber, "phonenumber");

            //  Check if email is valid:
            ValidateEmail(email);

            //  Check for admin rights selection:
            ValidateAdminRights(noRights, yesRights);

            // Validate date of birth:
            ValidateDOB(dob);

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
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

        //  Set
        private void ValidateEmail(string email)
        {
            string Pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (!Regex.IsMatch(email, Pattern))
            {
                throw new InvalidEmail();
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

    }
}

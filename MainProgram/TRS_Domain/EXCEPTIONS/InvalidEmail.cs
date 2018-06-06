using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.EXCEPTIONS
{
    public class InvalidEmail : Exception
    {
        public InvalidEmail() : base("The email is invalid") { }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.EXCEPTIONS
{
    public class PasswordNotFound : Exception
    {
        public PasswordNotFound() : base("Old password is incorrect.") { }
    }
}

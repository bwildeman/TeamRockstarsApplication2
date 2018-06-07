using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.EXCEPTIONS
{
    public class PasswordNotEqual : Exception
    {
        public PasswordNotEqual() : base("The passwords aren't equal.") { }
    }
}

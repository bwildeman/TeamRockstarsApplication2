using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.EXCEPTIONS
{
    public class InvalidDOB : Exception
    {
        public InvalidDOB() : base("The selected date of birth is invalid and should be in de past.") { }
    }
}

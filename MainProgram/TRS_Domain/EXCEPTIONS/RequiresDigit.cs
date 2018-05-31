using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.EXCEPTIONS
{
    public class RequiresDigit : Exception
    {
        public RequiresDigit(string input) : base($"{input} needs at least one digit.") { }
    }
}

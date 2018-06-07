using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.EXCEPTIONS
{
    public class StringContainsDigit : Exception
    {
        public StringContainsDigit(string fieldName) : base($"The {fieldName} contains a digit, sadly that isn't allowed.") { }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.EXCEPTIONS
{
    public class RequiresLetter : Exception
    {
        public RequiresLetter(string input) : base($"{input} requires at least one letter.") { }
    }
}

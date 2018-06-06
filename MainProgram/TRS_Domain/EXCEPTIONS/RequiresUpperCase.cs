using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.EXCEPTIONS
{
    public class RequiresUpperCase :Exception
    {
        public RequiresUpperCase(string input) : base($"{input} requires at leats an upper case.") { }
    }
}

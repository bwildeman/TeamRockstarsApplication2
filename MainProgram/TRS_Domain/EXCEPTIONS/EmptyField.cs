using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.EXCEPTIONS
{
    public class EmptyField : Exception
    {
        public EmptyField(string fieldName) : base($"The {fieldName} is a required field") { }
    }
}

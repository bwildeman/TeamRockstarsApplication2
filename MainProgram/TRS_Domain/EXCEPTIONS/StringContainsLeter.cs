using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.EXCEPTIONS
{
    public class StringContainsLeter : Exception
    {
        public StringContainsLeter(string fieldName) : base($"The {fieldName} contains leter(s), sadly this isn't allowed." ) { }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.EXCEPTIONS
{
    public class InvalidLoginCombination : Exception
    {
        public InvalidLoginCombination() : base("Login isn't possible, invalid combination.") { }
    }
}

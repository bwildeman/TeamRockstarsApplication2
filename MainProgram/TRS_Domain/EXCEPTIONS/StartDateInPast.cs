using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.EXCEPTIONS
{
     public class StartDateInPast : Exception
    {
        public StartDateInPast() : base("The start date shouldn't be in the past.") { }
    }
}

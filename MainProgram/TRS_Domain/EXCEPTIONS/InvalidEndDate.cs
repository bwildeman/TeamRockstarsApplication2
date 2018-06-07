using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.EXCEPTIONS
{
    public class InvalidEndDate : Exception
    {
        public InvalidEndDate() : base("Please check the end date, this is incorrect.") { }
    }
}

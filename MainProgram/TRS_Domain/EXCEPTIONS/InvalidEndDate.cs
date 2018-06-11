using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.EXCEPTIONS
{
    public class InvalidEndDate : Exception
    {
        public InvalidEndDate() : base("Please check the end date, it shouldn't before the start date.") { }
    }
}

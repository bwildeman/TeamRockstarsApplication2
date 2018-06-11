using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.EXCEPTIONS
{
    public class DescriptionTooShort : Exception
    {
        public DescriptionTooShort() : base("Your description should be a bit longer.") { }
    }
}

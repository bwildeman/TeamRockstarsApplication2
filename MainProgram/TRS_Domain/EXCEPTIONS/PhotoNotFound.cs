using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.EXCEPTIONS
{
    public class PhotoNotFound : Exception
    {
        public PhotoNotFound() : base("Selected file is not found.") { }
    }
}

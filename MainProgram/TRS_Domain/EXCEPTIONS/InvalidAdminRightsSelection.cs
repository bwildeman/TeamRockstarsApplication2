using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.EXCEPTIONS
{
    public class InvalidAdminRightsSelection : Exception
    {
        public InvalidAdminRightsSelection() : base("The current selection of admin rights is invalid.") { }
    }
}

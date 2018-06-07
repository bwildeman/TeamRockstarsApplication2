using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.EXCEPTIONS
{
    public class MaxPhotoSizeReached :Exception
    {
        public MaxPhotoSizeReached(string MaxSize) : base($"Photo size is too big, the size limit is currently {MaxSize}") { }
    }
}

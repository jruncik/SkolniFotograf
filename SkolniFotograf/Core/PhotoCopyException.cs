using System;

namespace SkolniFotograf.Core
{
    public class PhotoCopyException : Exception
    {
        public PhotoCopyException(string message) :
            base(message)
        {
        }
    }
}

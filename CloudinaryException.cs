using System;

namespace CloudinaryDotNet
{
    public class CloudinaryException : Exception
    {
        public CloudinaryException(string format) : base(format)
        {
            
        }
    }
}
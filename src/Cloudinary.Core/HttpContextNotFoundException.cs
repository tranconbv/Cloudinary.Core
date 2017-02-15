namespace CloudinaryDotNet
{
    public class HttpContextNotFoundException : CloudinaryException
    {
        public HttpContextNotFoundException(string format) : base(format)
        {
        }
    }
}
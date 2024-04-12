using System.Net;

namespace TAB.Library.Backend.Core.Exceptions.Base
{
    public abstract class BaseException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; } = HttpStatusCode.InternalServerError;
        public string Message { get; set; } = string.Empty;

        public BaseException(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
        public BaseException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}

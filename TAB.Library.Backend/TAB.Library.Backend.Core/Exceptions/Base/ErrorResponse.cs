using System.Net;

namespace TAB.Library.Backend.Core.Exceptions.Base
{
    public class ErrorResponse
    {
        public HttpStatusCode StatusCode { get; private set; }
        public string Title { get; private set; }
        public string Message { get; private set; }
        public ErrorResponse(HttpStatusCode statusCode, string title, string message)
        {
            Message = message;
            Title = title;
            StatusCode = statusCode;
        }
        public override string ToString()
        {
            return "{ " + $"\"StatusCode\":{(int)StatusCode}, \"Title\":{Title}, \"Message\":{Message}" + " }";
        }
    }
}

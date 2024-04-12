using System.Net;
using TAB.Library.Backend.Core.Exceptions.Base;

namespace TAB.Library.Backend.Core.Exceptions
{
    public class RequestValidationException : BaseException
    {
        public RequestValidationException(Dictionary<string, string[]> errorsDictionary) : base(HttpStatusCode.Forbidden)
        {
            string message = "";

            foreach(var error in errorsDictionary)
            {
                message += $"{error.Key}: {string.Join(". ", error.Value)}.\n";
            }

            Message = message;
        }
    }
}

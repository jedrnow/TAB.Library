using System.Net;
using TAB.Library.Backend.Core.Exceptions.Base;

namespace TAB.Library.Backend.Core.Exceptions
{
    public class UserUnauthorizedException : BaseException
    {
        public UserUnauthorizedException() : base(HttpStatusCode.Unauthorized)
        {
            Message = "Unauthorized.";
        }
    }
}

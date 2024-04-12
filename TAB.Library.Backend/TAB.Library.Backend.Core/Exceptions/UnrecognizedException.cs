using TAB.Library.Backend.Core.Exceptions.Base;

namespace TAB.Library.Backend.Core.Exceptions
{
    public class UnrecognizedException : BaseException
    {
        public UnrecognizedException() : base(System.Net.HttpStatusCode.InternalServerError)
        {
            Message = "Something went wrong...";
        }
    }
}

using TAB.Library.Backend.Core.Exceptions.Base;

namespace TAB.Library.Backend.Core.Exceptions
{
    public class RentalNotAvailableException : BaseException
    {
        public RentalNotAvailableException() : base(System.Net.HttpStatusCode.Forbidden)
        {
            Message = "Rental not possible - book is currently unavailable";
        }
    }
}

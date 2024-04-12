using System.Net;
using TAB.Library.Backend.Core.Exceptions.Base;

namespace TAB.Library.Backend.Core.Exceptions
{
    public class EntityAlreadyExistsException : BaseException
    {
        public EntityAlreadyExistsException(Type entityType) : base(HttpStatusCode.Forbidden)
        {
            Message = $"{entityType.Name} already exists.";
        }
    }
}

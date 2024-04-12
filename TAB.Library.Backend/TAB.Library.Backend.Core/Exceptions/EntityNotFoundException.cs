using System.Net;
using TAB.Library.Backend.Core.Exceptions.Base;

namespace TAB.Library.Backend.Core.Exceptions
{
    public class EntityNotFoundException : BaseException
    {
        public EntityNotFoundException(Type entityType) : base(HttpStatusCode.NotFound)
        {
            Message = $"{entityType.Name} was not found.";
        }
        public EntityNotFoundException(Type entityType, int id) : base(HttpStatusCode.NotFound)
        {
            Message = $"{entityType.Name} with ID = {id} was not found.";
        }
    }
}

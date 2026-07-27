using System.Net;

namespace LogixonBackend.Application.Exceptions.SupplierExceptions
{
    public class NotFoundSupplierByIdException : ApiException
    {
        public NotFoundSupplierByIdException(int id) 
            : base($"Not found supplier with id: {id}", HttpStatusCode.NotFound)
        {
        }
    }
}

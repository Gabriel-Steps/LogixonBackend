using System.Net;

namespace LogixonBackend.Application.Exceptions.ProductExceptions
{
    public class NotFoundProductByIdException : ApiException
    {
        public NotFoundProductByIdException(int id) 
            : base($"Product with ID {id} not found.", HttpStatusCode.NotFound)
        {
        }
    }
}

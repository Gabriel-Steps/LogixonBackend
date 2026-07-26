using System.Net;

namespace LogixonBackend.Application.Exceptions.CategoryExceptions
{
    public class NotFoundCategoryByIdException : ApiException
    {
        public NotFoundCategoryByIdException(int id) 
            : base($"Category with ID {id} not found.", HttpStatusCode.NotFound)
        {
        }
    }
}

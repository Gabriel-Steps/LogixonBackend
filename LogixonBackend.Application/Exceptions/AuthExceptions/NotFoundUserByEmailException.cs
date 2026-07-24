using System.Net;

namespace LogixonBackend.Application.Exceptions.AuthExceptions
{
    public class NotFoundUserByEmailException : ApiException
    {
        public NotFoundUserByEmailException(string email) 
            : base($"User with email {email} not found.", HttpStatusCode.NotFound)
        {
        }
    }
}

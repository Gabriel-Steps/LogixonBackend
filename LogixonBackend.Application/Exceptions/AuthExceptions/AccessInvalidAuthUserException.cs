using System.Net;

namespace LogixonBackend.Application.Exceptions.AuthExceptions
{
    public class AccessInvalidAuthUserException : ApiException
    {
        public AccessInvalidAuthUserException(string email) 
            : base($"Access invalid for: {email}", HttpStatusCode.Unauthorized)
        {
        }
    }
}

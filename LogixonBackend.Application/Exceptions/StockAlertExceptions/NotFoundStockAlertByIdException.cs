using System.Net;

namespace LogixonBackend.Application.Exceptions.StockAlertExceptions
{
    public class NotFoundStockAlertByIdException : ApiException
    {
        public NotFoundStockAlertByIdException(int id) 
            : base($"Not found stock alert by id: {id}", HttpStatusCode.NotFound)
        {
        }
    }
}

using System.Net;

namespace LogixonBackend.Application.Exceptions.StockMovementsExceptions
{
    public class NotFoundStockMovementByIdException : ApiException
    {
        public NotFoundStockMovementByIdException(int id) 
            : base($"Not found stock movement by id: {id}", HttpStatusCode.NotFound)
        {
        }
    }
}

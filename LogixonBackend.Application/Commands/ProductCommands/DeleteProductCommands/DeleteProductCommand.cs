using MediatR;

namespace LogixonBackend.Application.Commands.ProductCommands.DeleteProductCommands
{
    public class DeleteProductCommand(int id) : IRequest<Unit>
    {
        public int Id { get; set; } = id;
    }
}

using MediatR;

namespace LogixonBackend.Application.Commands.SupplierCommands.DeleteSupplierCommands
{
    public class DeleteSupplierCommand(int id) : IRequest<Unit>
    {
        public int Id { get; set; } = id;
    }
}

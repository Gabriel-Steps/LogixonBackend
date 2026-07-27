using MediatR;

namespace LogixonBackend.Application.Commands.SupplierCommands.CreateSupplierCommands
{
    public class CreateSupplierCommand : IRequest<Unit>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}

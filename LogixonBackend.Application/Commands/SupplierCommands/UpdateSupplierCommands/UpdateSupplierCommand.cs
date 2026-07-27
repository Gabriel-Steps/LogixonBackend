using MediatR;

namespace LogixonBackend.Application.Commands.SupplierCommands.UpdateSupplierCommands
{
    public class UpdateSupplierCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}

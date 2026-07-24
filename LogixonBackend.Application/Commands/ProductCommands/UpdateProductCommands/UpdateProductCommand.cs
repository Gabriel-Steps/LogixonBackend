using MediatR;

namespace LogixonBackend.Application.Commands.ProductCommands.UpdateProductCommands
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public int MinimumStock { get; set; }
        public int MaximumStock { get; set; }
        public int CategoryId { get; set; }
    }
}

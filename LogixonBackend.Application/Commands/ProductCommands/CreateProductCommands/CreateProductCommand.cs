using MediatR;

namespace LogixonBackend.Application.Commands.ProductCommands.CreateProductCommands
{
    public class CreateProductCommand : IRequest<Unit>
    {
        public string Name { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public int MinimumStock { get; set; }
        public int MaximumStock { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
    }
}

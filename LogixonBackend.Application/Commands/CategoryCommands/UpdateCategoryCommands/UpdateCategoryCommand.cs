using MediatR;

namespace LogixonBackend.Application.Commands.CategoryCommands.UpdateCategoryCommands
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}

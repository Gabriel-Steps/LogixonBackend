using MediatR;

namespace LogixonBackend.Application.Commands.CategoryCommands.CreateCategoryCommands
{
    public class CreateCategoryCommand : IRequest<Unit>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}

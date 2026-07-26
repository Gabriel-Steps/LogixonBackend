using MediatR;

namespace LogixonBackend.Application.Commands.CategoryCommands.DeleteCategoryCommands
{
    public class DeleteCategoryCommand(int id) : IRequest<Unit>
    {
        public int Id { get; } = id;
    }
}

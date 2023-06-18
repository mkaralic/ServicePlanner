using ServicePlanner.Application.Common.Mappings;
using ServicePlanner.Domain.Entities;

namespace ServicePlanner.Application.TodoLists.Queries.ExportTodos;
public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}

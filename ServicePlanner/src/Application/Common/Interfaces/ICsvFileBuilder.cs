using ServicePlanner.Application.TodoLists.Queries.ExportTodos;

namespace ServicePlanner.Application.Common.Interfaces;
public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}

using System.Globalization;
using CsvHelper.Configuration;
using ServicePlanner.Application.TodoLists.Queries.ExportTodos;

namespace ServicePlanner.Infrastructure.Files.Maps;
public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).Convert(c => c.Value.Done ? "Yes" : "No");
    }
}

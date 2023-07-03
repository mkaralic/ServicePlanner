using ServicePlanner.Application.Common.Mappings;
using ServicePlanner.Domain.Entities.ServicePlanner;

namespace ServicePlanner.Application.Employees.Queries.GetEmployeesWithPagination;
public class EmployeeBriefDto : IMapFrom<Employee>
{
    public int Id { get; set; }

    public int FullName { get; set; }
}

using Microsoft.EntityFrameworkCore;
using ServicePlanner.Domain.Entities;
using ServicePlanner.Domain.Entities.ServicePlanner;

namespace ServicePlanner.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    DbSet<Person> People { get; }
    DbSet<Customer> Customers { get; }
    DbSet<Employee> Employees { get; }
    DbSet<WorkOrder> WorkOrders { get; }
    DbSet<WorkOrderStatus> WorkOrderStatuses { get; }
    DbSet<WorkOrderStatusHistory> WorkOrderStatusHistoryItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

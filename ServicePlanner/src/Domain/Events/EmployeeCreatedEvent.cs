using ServicePlanner.Domain.Entities.ServicePlanner;

namespace ServicePlanner.Domain.Events;

public class EmployeeCreatedEvent : BaseEvent
{
    public EmployeeCreatedEvent(Employee item)
    {
        Item = item;
    }

    public Employee Item { get; }
}

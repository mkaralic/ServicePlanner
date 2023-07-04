using ServicePlanner.Domain.Entities.ServicePlanner;

namespace ServicePlanner.Domain.Events;

public class WorkOrderCreatedEvent : BaseEvent
{
    public WorkOrderCreatedEvent(WorkOrder item)
    {
        Item = item;
    }

    public WorkOrder Item { get; }
}

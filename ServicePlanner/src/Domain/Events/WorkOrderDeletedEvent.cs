using ServicePlanner.Domain.Entities.ServicePlanner;

namespace ServicePlanner.Domain.Events;

public class WorkOrderDeletedEvent : BaseEvent
{
    public WorkOrderDeletedEvent(WorkOrder item)
    {
        Item = item;
    }

    public WorkOrder Item { get; }
}

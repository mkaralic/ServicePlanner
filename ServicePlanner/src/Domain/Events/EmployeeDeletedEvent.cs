﻿using ServicePlanner.Domain.Entities.ServicePlanner;

namespace ServicePlanner.Domain.Events;

public class EmployeeDeletedEvent : BaseEvent
{
    public EmployeeDeletedEvent(Employee item)
    {
        Item = item;
    }

    public Employee Item { get; }
}

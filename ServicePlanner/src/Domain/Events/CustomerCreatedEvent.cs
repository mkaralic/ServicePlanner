﻿using ServicePlanner.Domain.Entities.ServicePlanner;

namespace ServicePlanner.Domain.Events;

public class CustomerCreatedEvent : BaseEvent
{
    public CustomerCreatedEvent(Customer item)
    {
        Item = item;
    }

    public Customer Item { get; }
}

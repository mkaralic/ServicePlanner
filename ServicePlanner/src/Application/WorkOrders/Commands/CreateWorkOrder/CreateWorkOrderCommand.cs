using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ServicePlanner.Application.Common.Interfaces;
using ServicePlanner.Domain.Entities;
using ServicePlanner.Domain.Entities.ServicePlanner;
using ServicePlanner.Domain.Events;

namespace ServicePlanner.Application.WorkOrders.Commands.CreateWorkOrder;
public record CreateWorkOrderCommand : IRequest<int>
{
    public int WorkOrderStatusId { get; set; }
    public int? CustomerId { get; set; }
    public int? EmployeeId { get; set; }
    public string? Notes { get; set; }
    public string ServiceDescription { get; set; }
    public decimal? Total { get; set; }
}

public class CreateWorkOrderCommandHandler : IRequestHandler<CreateWorkOrderCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateWorkOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateWorkOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = new WorkOrder
        {
            WorkOrderStatusId = request.WorkOrderStatusId,
            CustomerId = request.CustomerId,
            EmployeeId = request.EmployeeId,
            ServiceDescription = request.ServiceDescription,
            Total = request.Total,
            Notes = request.Notes
        };

        entity.AddDomainEvent(new WorkOrderCreatedEvent(entity));

        _context.WorkOrders.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}

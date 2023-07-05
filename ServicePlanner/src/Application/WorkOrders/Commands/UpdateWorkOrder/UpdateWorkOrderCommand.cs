using MediatR;
using ServicePlanner.Application.Common.Exceptions;
using ServicePlanner.Application.Common.Interfaces;
using ServicePlanner.Domain.Entities;
using ServicePlanner.Domain.Entities.ServicePlanner;

namespace ServicePlanner.Application.WorkOrders.Commands.UpdateWorkOrder;
public record UpdateWorkOrderCommand : IRequest
{
    public int Id { get; init; }
    public int WorkOrderStatusId { get; set; }
    public int? CustomerId { get; set; }
    public int? EmployeeId { get; set; }
    public string ServiceDescription { get; set; }
    public decimal? Total { get; set; }
    public string? Notes { get; set; }
}

public class UpdateWorkOrderCommandHandler : IRequestHandler<UpdateWorkOrderCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateWorkOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateWorkOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.WorkOrders
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(WorkOrder), request.Id);
        }

        (entity.WorkOrderStatusId, entity.CustomerId, entity.EmployeeId, entity.ServiceDescription, entity.Total, entity.Notes)
            = (request.WorkOrderStatusId, request.CustomerId, request.EmployeeId, request.ServiceDescription, request.Total, request.Notes);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

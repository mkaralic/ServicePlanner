using MediatR;
using ServicePlanner.Application.Common.Exceptions;
using ServicePlanner.Application.Common.Interfaces;
using ServicePlanner.Domain.Entities;
using ServicePlanner.Domain.Entities.ServicePlanner;
using ServicePlanner.Domain.Events;

namespace ServicePlanner.Application.WorkOrders.Commands.DeleteWorkOrder;
public record DeleteWorkOrderCommand(int Id) : IRequest;

public class DeleteWorkOrderCommandHandler : IRequestHandler<DeleteWorkOrderCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteWorkOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteWorkOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.WorkOrders
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(WorkOrder), request.Id);
        }

        _context.WorkOrders.Remove(entity);

        entity.AddDomainEvent(new WorkOrderDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

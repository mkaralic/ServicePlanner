using MediatR;
using ServicePlanner.Application.Common.Exceptions;
using ServicePlanner.Application.Common.Interfaces;
using ServicePlanner.Domain.Entities.ServicePlanner;
using ServicePlanner.Domain.Events;

namespace ServicePlanner.Application.Customers.Commands.DeleteCustomer;
public record DeleteCustomerCommand(int Id) : IRequest;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCustomerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Customers
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Customer), request.Id);
        }

        _context.Customers.Remove(entity);

        entity.AddDomainEvent(new CustomerDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

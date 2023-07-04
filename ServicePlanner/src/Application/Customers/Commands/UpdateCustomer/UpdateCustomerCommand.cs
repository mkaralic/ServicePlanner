using MediatR;
using ServicePlanner.Application.Common.Exceptions;
using ServicePlanner.Application.Common.Interfaces;
using ServicePlanner.Domain.Entities.ServicePlanner;

namespace ServicePlanner.Application.Customers.Commands.UpdateCustomer;
public record UpdateCustomerCommand : IRequest
{
    public int Id { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Notes { get; set; }
}

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCustomerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Customers
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Customer), request.Id);
        }

        (entity.FirstName, entity.LastName, entity.Phone, entity.Address, entity.City, entity.Country, entity.Notes)
            = (request.FirstName, request.LastName, request.Phone, request.Address, request.City, request.Country, request.Notes);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

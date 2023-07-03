using MediatR;
using ServicePlanner.Application.Common.Exceptions;
using ServicePlanner.Application.Common.Interfaces;
using ServicePlanner.Domain.Entities;
using ServicePlanner.Domain.Entities.ServicePlanner;

namespace ServicePlanner.Application.Employees.Commands.UpdateEmployee;
public record UpdateEmployeeCommand : IRequest
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

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Employees
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Employee), request.Id);
        }

        (entity.FirstName, entity.LastName, entity.Phone, entity.Address, entity.City, entity.Country, entity.Notes) 
            = (request.FirstName, request.LastName, request.Phone, request.Address, request.City, request.Country, request.Notes);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

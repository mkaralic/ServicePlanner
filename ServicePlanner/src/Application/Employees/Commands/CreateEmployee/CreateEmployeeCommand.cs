using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ServicePlanner.Application.Common.Interfaces;
using ServicePlanner.Domain.Entities;
using ServicePlanner.Domain.Entities.ServicePlanner;
using ServicePlanner.Domain.Events;

namespace ServicePlanner.Application.Employees.Commands.CreateEmployee;
public record CreateEmployeeCommand : IRequest<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Notes { get; set; }
}

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = new Employee
        {
            FirstName = request.FirstName, LastName = request.LastName,
            Phone = request.Phone, Address = request.Address,
            City = request.City, Country = request.Country,
            Notes = request.Notes
        };

        entity.AddDomainEvent(new EmployeeCreatedEvent(entity));

        _context.Employees.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}

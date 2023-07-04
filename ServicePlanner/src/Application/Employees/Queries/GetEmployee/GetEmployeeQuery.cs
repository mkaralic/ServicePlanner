using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using ServicePlanner.Application.Common.Interfaces;
using ServicePlanner.Application.Common.Mappings;
using ServicePlanner.Application.Common.Models;
using ServicePlanner.Application.Employees.Queries.GetEmployeesWithPagination;
using ServicePlanner.Domain.Entities.ServicePlanner;

namespace ServicePlanner.Application.Employees.Queries.GetEmployee;
public record GetEmployeeQuery : IRequest<Employee>
{
    public int Id { get; init; }
}

public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, Employee>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEmployeeQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Employee> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Employees
            .FindAsync(new object[] { request.Id }, cancellationToken);

        return entity;
    }
}

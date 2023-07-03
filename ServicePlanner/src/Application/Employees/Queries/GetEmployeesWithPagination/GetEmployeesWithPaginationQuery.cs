using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using ServicePlanner.Application.Common.Interfaces;
using ServicePlanner.Application.Common.Mappings;
using ServicePlanner.Application.Common.Models;

namespace ServicePlanner.Application.Employees.Queries.GetEmployeesWithPagination;
public record GetEmployeesWithPaginationQuery : IRequest<PaginatedList<EmployeeBriefDto>>
{
    public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetEmployeesWithPaginationQueryHandler : IRequestHandler<GetEmployeesWithPaginationQuery, PaginatedList<EmployeeBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEmployeesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<EmployeeBriefDto>> Handle(GetEmployeesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Employees
            .OrderBy(x => x.FirstName)
            .ProjectTo<EmployeeBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}

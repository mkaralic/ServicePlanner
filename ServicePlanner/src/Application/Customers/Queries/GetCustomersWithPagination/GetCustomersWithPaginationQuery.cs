using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using ServicePlanner.Application.Common.Interfaces;
using ServicePlanner.Application.Common.Mappings;
using ServicePlanner.Application.Common.Models;

namespace ServicePlanner.Application.Customers.Queries.GetCustomersWithPagination;
public record GetCustomersWithPaginationQuery : IRequest<PaginatedList<CustomerBriefDto>>
{
    public string Name { get; set; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetCustomersWithPaginationQueryHandler : IRequestHandler<GetCustomersWithPaginationQuery, PaginatedList<CustomerBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCustomersWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CustomerBriefDto>> Handle(GetCustomersWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Customers
            .Where(x => string.IsNullOrEmpty(request.Name) || x.FirstName.Contains(request.Name) || x.LastName.Contains(request.Name))
            .OrderBy(x => x.FirstName)
            .ProjectTo<CustomerBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}

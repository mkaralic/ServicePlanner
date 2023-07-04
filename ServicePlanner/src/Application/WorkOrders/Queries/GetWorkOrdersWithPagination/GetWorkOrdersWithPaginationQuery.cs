using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using ServicePlanner.Application.Common.Interfaces;
using ServicePlanner.Application.Common.Mappings;
using ServicePlanner.Application.Common.Models;
using ServicePlanner.Application.WorkOrders.Queries.GetWorkOrdersWithPagination;

namespace ServicePlanner.Application.WorkOrders.Queries.GetWorkOrdersWithPagination;
public record GetWorkOrdersWithPaginationQuery : IRequest<PaginatedList<WorkOrderBriefDto>>
{
    public string Name { get; set; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetWorkOrdersWithPaginationQueryHandler : IRequestHandler<GetWorkOrdersWithPaginationQuery, PaginatedList<WorkOrderBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetWorkOrdersWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<WorkOrderBriefDto>> Handle(GetWorkOrdersWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.WorkOrders
            // should be able to be filtered by status, customer, employee
            //.Where(x => string.IsNullOrEmpty(request.Name) || x.FirstName.Contains(request.Name) || x.LastName.Contains(request.Name))
            .OrderByDescending(x => x.Created)
            .ProjectTo<WorkOrderBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServicePlanner.Application.Common.Interfaces;
using ServicePlanner.Application.Common.Mappings;
using ServicePlanner.Application.Common.Models;
using ServicePlanner.Application.WorkOrders.Queries.GetWorkOrdersWithPagination;
using ServicePlanner.Domain.Entities.ServicePlanner;

namespace ServicePlanner.Application.WorkOrderStatuses.Queries.GetWorkOrderStatuses;
public record GetWorkOrderStatusesQuery : IRequest<List<WorkOrderStatus>>
{
    public string Name { get; set; }
}

public class GetWorkOrderStatusesQueryHandler : IRequestHandler<GetWorkOrderStatusesQuery, List<WorkOrderStatus>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetWorkOrderStatusesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<WorkOrderStatus>> Handle(GetWorkOrderStatusesQuery request, CancellationToken cancellationToken)
    {
        return await _context.WorkOrderStatuses
            .OrderBy(x => x.Id).ToListAsync();
    }
}

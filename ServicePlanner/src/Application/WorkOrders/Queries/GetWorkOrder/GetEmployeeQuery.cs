using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using ServicePlanner.Application.Common.Interfaces;
using ServicePlanner.Application.Common.Mappings;
using ServicePlanner.Application.Common.Models;
using ServicePlanner.Application.WorkOrders.Queries.GetWorkOrdersWithPagination;
using ServicePlanner.Domain.Entities.ServicePlanner;

namespace ServicePlanner.Application.WorkOrders.Queries.GetWorkOrder;
public record GetWorkOrderQuery : IRequest<WorkOrder>
{
    public int Id { get; init; }
}

public class GetWorkOrderQueryHandler : IRequestHandler<GetWorkOrderQuery, WorkOrder>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetWorkOrderQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<WorkOrder> Handle(GetWorkOrderQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.WorkOrders
            .FindAsync(new object[] { request.Id }, cancellationToken);

        return entity;
    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            .Include(wo => wo.WorkOrderStatus).Include(wo => wo.Customer).Include(wo => wo.Employee)
            .Where(wo => wo.Id == request.Id).SingleAsync();
            //.FindAsync(new object[] { request.Id }, cancellationToken);

        return entity;
    }
}

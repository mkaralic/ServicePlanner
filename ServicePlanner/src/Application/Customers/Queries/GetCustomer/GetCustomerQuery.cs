using AutoMapper;
using MediatR;
using ServicePlanner.Application.Common.Interfaces;
using ServicePlanner.Domain.Entities.ServicePlanner;

namespace ServicePlanner.Application.Customers.Queries.GetCustomer;
public record GetCustomerQuery : IRequest<Customer>
{
    public int Id { get; init; }
}

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, Customer>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCustomerQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Customer> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Customers
            .FindAsync(new object[] { request.Id }, cancellationToken);

        return entity;
    }
}

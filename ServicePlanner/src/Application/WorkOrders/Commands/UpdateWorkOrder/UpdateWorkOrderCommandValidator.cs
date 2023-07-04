using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ServicePlanner.Application.Common.Interfaces;
using ServicePlanner.Application.WorkOrders.Commands.CreateWorkOrder;

namespace ServicePlanner.Application.WorkOrders.Commands.UpdateWorkOrder;
public class UpdateWorkOrderCommandValidator : AbstractValidator<UpdateWorkOrderCommand>
{
    private readonly IApplicationDbContext _context;
    public UpdateWorkOrderCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.WorkOrderStatusId)
            .Must(id => _context.WorkOrderStatuses.Any(wos => wos.Id == id)).WithMessage("Status doesn't exist.")
            .NotEmpty().WithMessage("Status is required.");

        // check if customerId is not null, then it must exist in customers
        RuleFor(x => x.CustomerId)
            .Must(customerId => !customerId.HasValue || _context.Customers.Any(c => c.Id == customerId)).WithMessage("Customer doesn't exist.");

        // check if WorkOrderId is not null, then it must exist in WorkOrders
        RuleFor(x => x.EmployeeId)
            .Must(employeeId => !employeeId.HasValue || _context.Customers.Any(c => c.Id == employeeId)).WithMessage("Employee doesn't exist.");
    }
}

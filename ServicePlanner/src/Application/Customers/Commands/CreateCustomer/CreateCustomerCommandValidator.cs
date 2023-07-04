using FluentValidation;

namespace ServicePlanner.Application.Customers.Commands.CreateCustomer;
public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(v => v.FirstName)
            .MaximumLength(30)
            .NotEmpty();

        RuleFor(v => v.LastName)
            .MaximumLength(50);

        RuleFor(v => v.Phone)
            .MaximumLength(20);

        RuleFor(v => v.Address)
            .MaximumLength(200);

        RuleFor(v => v.City)
            .MaximumLength(50);

        RuleFor(v => v.Country)
            .MaximumLength(50);
    }
}

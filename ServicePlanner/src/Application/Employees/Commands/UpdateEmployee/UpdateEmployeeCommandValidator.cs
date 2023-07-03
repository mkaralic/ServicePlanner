using FluentValidation;
using ServicePlanner.Application.Employees.Commands.CreateEmployee;

namespace ServicePlanner.Application.Employees.Commands.UpdateEmployee;
public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
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

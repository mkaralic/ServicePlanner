﻿using FluentValidation;

namespace ServicePlanner.Application.Customers.Queries.GetCustomersWithPagination;
public class GetCustomersWithPaginationQueryValidator : AbstractValidator<GetCustomersWithPaginationQuery>
{
    public GetCustomersWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}

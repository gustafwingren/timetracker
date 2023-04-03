// <copyright file="CreateCustomerValidation.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using FluentValidation;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.CreateCustomer;

public class CreateCustomerValidation : Validator<CreateCustomerRequest>
{
    public CreateCustomerValidation()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name is required")
            .NotEmpty().WithMessage("Name is required");

        RuleFor(x => x.Number)
            .NotNull().WithMessage("Number is required")
            .NotEmpty().WithMessage("Number is required");

        RuleForEach(x => x.Activities)
            .ChildRules(
                x =>
                {
                    x.RuleFor(y => y.Name)
                        .NotNull().WithMessage("Name is required")
                        .NotEmpty().WithMessage("Name is required");
                }).When(x => x.Activities.Any());
    }
}
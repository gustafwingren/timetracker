// <copyright file="UpdateCustomerValidation.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using FluentValidation;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.UpdateCustomer;

public class UpdateCustomerValidation : Validator<UpdateCustomerRequest>
{
    public UpdateCustomerValidation()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name is required")
            .NotEmpty().WithMessage("Name is required");

        RuleFor(x => x.Number)
            .NotNull().WithMessage("Number is required")
            .NotEmpty().WithMessage("Number is required");
    }
}
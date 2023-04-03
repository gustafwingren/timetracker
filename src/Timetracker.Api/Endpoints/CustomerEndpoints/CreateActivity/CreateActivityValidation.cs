// <copyright file="CreateActivityValidation.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using FluentValidation;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.CreateActivity;

public class CreateActivityValidation : Validator<CreateActivityRequest>
{
    public CreateActivityValidation()
    {
        RuleFor(x => x.CustomerId)
            .NotNull().WithMessage("CustomerId is required");

        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name is required")
            .NotEmpty().WithMessage("Name cannot be empty");
    }
}
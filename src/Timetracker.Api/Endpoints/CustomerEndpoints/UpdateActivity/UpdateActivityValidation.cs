// <copyright file="UpdateActivityValidation.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using FluentValidation;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.UpdateActivity;

public class UpdateActivityValidation : Validator<UpdateActivityRequest>
{
    public UpdateActivityValidation()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name is required")
            .NotEmpty().WithMessage("Name is required");
    }
}
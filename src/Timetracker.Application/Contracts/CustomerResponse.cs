// <copyright file="CustomerResponse.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Timetracker.Application.Common.Interfaces;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Application.Contracts;

public record CustomerResponse
(
    CustomerId Id,
    string Name,
    string Number,
    IEnumerable<ActivityResponse> Activities) : BaseResponse
{
    public override Guid Guid => Id.Value;
}
// <copyright file="ActivityResponse.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Timetracker.Application.Common.Interfaces;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Application.Contracts;

public record ActivityResponse(ActivityId Id, string Name) : BaseResponse
{
    public override Guid Guid => Id.Value;
}
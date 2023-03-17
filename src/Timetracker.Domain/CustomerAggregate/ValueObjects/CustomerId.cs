// <copyright file="CustomerId.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using StronglyTypedIds;

namespace Timetracker.Domain.CustomerAggregate.ValueObjects;

[StronglyTypedId(StronglyTypedIdBackingType.Guid, StronglyTypedIdConverter.SystemTextJson)]
public partial struct CustomerId
{
}
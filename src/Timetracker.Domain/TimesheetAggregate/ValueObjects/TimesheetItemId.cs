// <copyright file="TimesheetItemId.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using StronglyTypedIds;

namespace Timetracker.Domain.TimesheetAggregate.ValueObjects;

[StronglyTypedId(StronglyTypedIdBackingType.Guid, StronglyTypedIdConverter.SystemTextJson)]
public partial struct TimesheetItemId
{
}
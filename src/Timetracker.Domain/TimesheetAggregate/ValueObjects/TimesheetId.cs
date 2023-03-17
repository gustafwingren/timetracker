// <copyright file="TimesheetId.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using StronglyTypedIds;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Domain.TimesheetAggregate.ValueObjects;

[StronglyTypedId(StronglyTypedIdBackingType.Guid, StronglyTypedIdConverter.SystemTextJson)]
public partial struct TimesheetId : StronglyTypedId
{
}
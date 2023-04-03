// <copyright file="ActivityResponseMap.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Timetracker.Application.Contracts;
using Timetracker.Domain.CustomerAggregate.Entities;

namespace Timetracker.Application.Mapping;

public static class ActivityResponseMap
{
    public static ActivityResponse Map(this Activity activity)
    {
        return new ActivityResponse(activity.Id, activity.Name);
    }
}